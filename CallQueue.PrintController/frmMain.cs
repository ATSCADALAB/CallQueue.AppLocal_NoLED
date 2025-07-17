using CallQueue.Core;
using Newtonsoft.Json;
using Raspberry.IO.GeneralPurpose;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CallQueue.PrintController
{
    public partial class frmMain : Form
    {
        #region Members

        public ISQLHelper SQLHelper { get; set; }
        public List<Line> Lines { get; set; }
        public List<Service> Services { get; set; }
        public Dictionary<Input, Service> InputServiceDictionary { get; set; }
        public PrinterManager PrinterSetting { get; set; }
        public ProcessorPin SirenOutputPin { get; set; }
        public ProcessorPin ResetInputPin { get; set; }
        public Dictionary<Input, bool> InputValueDictionary { get; set; }
        bool IsBusy { get; set; }
        public bool IsInputPositive { get; set; }
        public string NumberFormat { get; set; }
        public bool IsConnectToServer { get; set; }
        public int NumberOfCopy { get; set; } = 1;

        #endregion

        #region Private members

        string constr;
        string configPath;
        string printContentPath;
        string parametersPath;
        string inputToServicePath;
        string applicationPath;
        DateTime previousDate;
        DateTime currentDate;

        #endregion

        #region IO Config

        Input resetInput;
        Output sirenOutput;
        List<Input> serviceInputs;
        string[] configs; 

        #endregion

        public frmMain()
        {
            InitializeComponent();
            Load += FrmMain_Load;
            FormClosing += FrmMain_FormClosing;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    if (IsConnectedToInternet("google.com.vn") != true)
            //    {
            //        Process proc = new Process();
            //        proc.StartInfo.FileName = "sudo";
            //        proc.StartInfo.Arguments = "sudo hwclock -s";
            //        proc.Start();
            //        proc.WaitForExit();
            //    }
            //    else
            //    {

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            applicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            configPath = applicationPath + "/config.txt";
            printContentPath = applicationPath + "/printContent.txt";
            parametersPath = applicationPath + "/parameters.txt";
            inputToServicePath = applicationPath + "/inputToService.txt";
            Console.WriteLine($"Application Path: {applicationPath}");
            configs = ReadAllLines(configPath);

            constr = configs[0].Split('|')[0];
            //Detect negative edge of input
            IsInputPositive = Convert.ToBoolean(configs[1].Split('|')[0]);
            Console.WriteLine($"Input Positive: {IsInputPositive}");

            NumberOfCopy = Convert.ToInt32(configs[2].Split('|')[0]);
            Console.WriteLine($"Number of copy: {NumberOfCopy}");

            SQLHelper = new MySQLHelper();
            SQLHelper.ConnectionString = constr;
            PrinterSetting = new PrinterManager(SQLHelper);

            GetCurrentDateTime();

            try
            {
                Services = JsonConvert.DeserializeObject<List<Service>>(ReadAllText(inputToServicePath));
                if (Services == null)
                    Console.WriteLine("Service is null");
            }
            catch { }

            try
            {
                var param = ReadAllLines(parametersPath);
                previousDate = Convert.ToDateTime(param[0]);
                Console.WriteLine(previousDate);
            }
            catch { }

            if (previousDate.ToString("dd/MM/yyyy") != currentDate.ToString("dd/MM/yyyy"))
            {
                foreach (var service in Services)
                {
                    service.CurrentNumber = 0;
                }
            }

            WriteText(parametersPath, currentDate.ToString("yyyy-MM-dd"));

            try
            {
                Lines = JsonConvert.DeserializeObject<List<Line>>(ReadAllText(printContentPath));
                if (Lines == null)
                {
                    InitDefaultLines();
                    WriteText(printContentPath, JsonConvert.SerializeObject(Lines));
                }
            }
            catch { }

            if (IsConnectToServer)
            {
                try
                {
                    PrinterSetting.Reset();
                    var newLines = GetLines();
                    if (newLines != null)
                    {
                        Lines = newLines;
                        WriteText(printContentPath, JsonConvert.SerializeObject(Lines));
                    }

                    var newService = PrinterSetting.GetAllServices();
                    if (newService != null)
                    {
                        Services = newService;
                        WriteText(inputToServicePath, JsonConvert.SerializeObject(Services));
                    }
                    NumberFormat = PrinterSetting.GetNumberFormat();

                    #region IO config

                    try
                    {
                        int resetPin = PrinterSetting.GetResetInputPin();
                        if (resetPin >= 0)
                        {
                            ResetInputPin = ((ConnectorPin)resetPin).ToProcessor();
                            Console.WriteLine($"Reset input pin: {ResetInputPin}");
                            resetInput = new Input("Reset", ((ConnectorPin)resetPin).ToProcessor());
                            Console.WriteLine($"Init input: {ResetInputPin}");
                            resetInput.ValueChanged += ResetInput_ValueChanged;
                            Console.WriteLine($"Register event value changed");
                            ioSettings.AddInput(resetInput);
                            Console.WriteLine($"Add reset Input: {resetInput.ProcessorPin}");
                        }

                        int sirenPin = 26;
                        if (sirenPin >= 0)
                        {
                            SirenOutputPin = ((ConnectorPin)sirenPin).ToProcessor();
                            Console.WriteLine($"Siren Output Pin: {SirenOutputPin}");
                            sirenOutput = new Output("Siren", ((ConnectorPin)sirenPin).ToProcessor());
                            sirenOutput.ValueChanged += SirenOutput_ValueChanged;
                            ioSettings.AddOutput(sirenOutput);
                            Console.WriteLine($"Add siren Input: {sirenOutput.ProcessorPin}");
                        }

                        serviceInputs = new List<Input>();
                        InputServiceDictionary = new Dictionary<Input, Service>();
                        foreach (var service in Services)
                        {
                            Input serviceInput = new Input(service.Name, ((ConnectorPin)service.InputPin).ToProcessor());
                            serviceInputs.Add(serviceInput);
                            serviceInput.ValueChanged += ServiceInput_ValueChanged;
                            InputServiceDictionary.Add(serviceInput, service);
                            ioSettings.AddInput(serviceInput);
                            Console.WriteLine($"Add service Input: {service.Name} - {serviceInput.ProcessorPin}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                NumberFormat = "000";
                try
                {
                    serviceInputs = new List<Input>();
                    InputServiceDictionary = new Dictionary<Input, Service>();
                    foreach (var service in Services)
                    {
                        Input serviceInput = new Input(service.Name, ((ConnectorPin)service.InputPin).ToProcessor());
                        serviceInputs.Add(serviceInput);
                        serviceInput.ValueChanged += ServiceInput_ValueChanged;
                        InputServiceDictionary.Add(serviceInput, service);
                        ioSettings.AddInput(serviceInput);
                        Console.WriteLine($"Add service Input: {service.Name} - {serviceInput.ProcessorPin}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            // Start read input continuity
            ioSettings.BeginRead();

            

            // Open printer serial port
            serialPrinter1.Open();
        }

        private void GetCurrentDateTime()
        {
            //try
            //{
            //    if (IsConnectToServer)
            //    {
            //        DataTable dt = SQLHelper.ExecuteQuery("select now()");
            //        if (dt != null && dt.Rows.Count > 0)
            //        {
            //            return Convert.ToDateTime(dt.Rows[0][0].ToString());
            //        }
            //    }
            //    return DateTime.MinValue;
            //}
            //catch
            //{
            //    return DateTime.MinValue;
            //}

            try
            {
                DataTable dt = SQLHelper.ExecuteQuery("select now()");
                if (dt != null && dt.Rows.Count > 0)
                {
                    currentDate = Convert.ToDateTime(dt.Rows[0][0].ToString());
                    IsConnectToServer = true;
                    Console.WriteLine("Connect to server success.");
                }
                else
                {
                    currentDate = DateTime.Now;
                    IsConnectToServer = false;
                    Console.WriteLine("Connect to server fail.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                IsConnectToServer = false;
                Console.WriteLine("Connect to server fail.");
            }
        }

        private List<Line> GetLines()
        {
            try
            {
                if (IsConnectToServer)
                {
                    Lines = PrinterSetting.GetAllLines();
                    if (Lines == null)
                        InitDefaultLines();
                    return Lines;
                }
                return Lines;
            }
            catch { return null; }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialPrinter1.Close();
            }
            catch { }
        }

        private void ServiceInput_ValueChanged(object sender, IOValueChangedEventArgs e)
        {
            try
            {                
                if (IsInputPositive && e.NewValue || !IsInputPositive && !e.NewValue)
                {
                    Console.WriteLine($"{(sender as Input).Name}: {e.NewValue}");

                    if (!IsBusy)
                    {
                        Service service = InputServiceDictionary[sender as Input];
                        GetCurrentDateTime();
                        sirenOutput.Write(true);
                        Thread.Sleep(500);
                        sirenOutput.Write(false);
                        if (IsConnectToServer)
                        {
                            var parameter = PrinterSetting.GetNextPrintParameter(service.Id);
                            if (parameter.NextNumber != 0)
                            {
                                string number = "";
                                if (string.IsNullOrEmpty(NumberFormat))
                                {
                                    number = parameter.NextNumber.ToString();
                                }
                                else
                                {
                                    try
                                    {
                                        number = parameter.NextNumber.ToString(NumberFormat);
                                    }
                                    catch { number = parameter.NextNumber.ToString(); }
                                }
                                number = number.Insert(0, parameter.Mask);
                                Print(GetLines(), 1000, number, parameter.ServiceName);
                                service.CurrentNumber++;
                                WriteText(inputToServicePath, JsonConvert.SerializeObject(Services));
                            }
                        }
                        else
                        {
                            if (service.CurrentNumber >= 999)
                                service.CurrentNumber = 0;

                            service.CurrentNumber++;

                            string number = service.CurrentNumber.ToString(NumberFormat);
                            number = number.Insert(0, service.Mark);
                            Print(GetLines(), 1000, number, service.Name);

                            WriteText(inputToServicePath, JsonConvert.SerializeObject(Services));
                        }
                    }
                    else
                        Console.WriteLine("Too busy.");
                }
            }
            catch { }
        }

        private void SirenOutput_ValueChanged(object sender, IOValueChangedEventArgs e)
        { 
            Console.WriteLine($"Siren output value changed: {e.NewValue}");
        }

        private void ResetInput_ValueChanged(object sender, IOValueChangedEventArgs e)
        {
            Console.WriteLine($"Reset input value changed: {e.NewValue}");
        }

        public bool Print(List<Line> lines, int delay, params string[] parameters)
        {
            try
            {
                DateTime dt = currentDate;
                string date = dt != DateTime.MinValue ? dt.ToString("dd/MM/yyyy") : "";
                string time = dt != DateTime.MinValue ? dt.ToString("HH:mm:ss") : "";
                string datetime = dt != DateTime.MinValue ? dt.ToString("dd/MM/yyyy HH:mm:ss") : "";

                IsBusy = true;
                for (int count = 0; count < NumberOfCopy; count++)
                {
                    if (lines.Count > 0)
                    {
                        Line lastLine = lines[0];
                        serialPrinter1.SetPrintMode((byte)lastLine.PrintMode);
                        byte height = (byte)lastLine.HeightSize;
                        byte width = (byte)lastLine.WidthSize;
                        serialPrinter1.SetFontSize(Convert.ToByte(height + width));
                        serialPrinter1.Justify((byte)lastLine.Justify);
                        for (int i = 0; i < lines.Count; i++)
                        {
                            Line currentLine = lines[i];

                            if (string.IsNullOrWhiteSpace(currentLine.Text))
                            {
                                serialPrinter1.WriteLine("\r");
                            }
                            else
                            {
                                serialPrinter1.SetPrintMode((byte)currentLine.PrintMode);
                                serialPrinter1.SetFontSize(Convert.ToByte((byte)currentLine.HeightSize + (byte)currentLine.WidthSize));
                                serialPrinter1.Justify((byte)currentLine.Justify);

                                string text = currentLine.Text;
                                for (int k = 0; k < parameters.Length; k++)
                                {
                                    if (text.Contains("{" + k.ToString() + "}"))
                                        text = text.Replace("{" + k.ToString() + "}", parameters[k]);
                                    else if (text.Contains("{Date}"))
                                        text = text.Replace("{Date}", date);
                                    else if (text.Contains("{Time}"))
                                        text = text.Replace("{Time}", time);
                                    else if (text.Contains("{DateTime}"))
                                        text = text.Replace("{DateTime}", datetime);
                                }

                                serialPrinter1.WriteLine(text);
                            }
                            lastLine = currentLine;
                        }
                        serialPrinter1.CutPaper();
                    }

                }
                Thread.Sleep(delay);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error print paper: {ex.Message}");
                return false;
            }
            finally { IsBusy = false; }
        }

        private void InitDefaultLines()
        {
            Lines = new List<Line>();
            Lines.Add(new Line()
            {
                HeightSize = HeightSize.OneTimes,
                WidthSize = WidthSize.OneTimes,
                Justify = JustifyMode.Center,
                PrintMode = PrintMode.FontA_12x24,
                Text = "================================================"
            });
            Lines.Add(new Line()
            {
                HeightSize = HeightSize.TwoTimes,
                WidthSize = WidthSize.TwoTimes,
                Justify = JustifyMode.Center,
                PrintMode = PrintMode.Underline,
                Text = "CTY TNHH Giao Hang Flex Speed"
            });
            Lines.Add(new Line());
            Lines.Add(new Line()
            {
                HeightSize = HeightSize.OneTimes,
                WidthSize = WidthSize.OneTimes,
                Justify = JustifyMode.Center,
                PrintMode = PrintMode.FontA_12x24,
                Text = "Dia diem kinh doanh so 29"
            });
            Lines.Add(new Line());
            Lines.Add(new Line()
            {
                HeightSize = HeightSize.FourTimes,
                WidthSize = WidthSize.FiveTime,
                Justify = JustifyMode.Center,
                PrintMode = PrintMode.Bolder,
                Text = "{0}"
            });
            Lines.Add(new Line());
            Lines.Add(new Line()
            {
                HeightSize = HeightSize.OneTimes,
                WidthSize = WidthSize.OneTimes,
                Justify = JustifyMode.Center,
                PrintMode = PrintMode.FontA_12x24,
                Text = "(Vui long cho phan hoi tu bo phan nhap hang)"
            });
            Lines.Add(new Line());
            Lines.Add(new Line()
            {
                HeightSize = HeightSize.TwoTimes,
                WidthSize = WidthSize.TwoTimes,
                Justify = JustifyMode.Center,
                PrintMode = PrintMode.Underline,
                Text = "{1}"
            });
            Lines.Add(new Line());
            Lines.Add(new Line()
            {
                HeightSize = HeightSize.OneTimes,
                WidthSize = WidthSize.OneTimes,
                Justify = JustifyMode.Center,
                PrintMode = PrintMode.FontA_12x24,
                Text = "Date: {Date}     Time: {Time}"
            });
            Lines.Add(new Line()
            {
                HeightSize = HeightSize.OneTimes,
                WidthSize = WidthSize.OneTimes,
                Justify = JustifyMode.Center,
                PrintMode = PrintMode.FontA_12x24,
                Text = "================================================"
            });
            Lines.Add(new Line()
            {
                HeightSize = HeightSize.OneTimes,
                WidthSize = WidthSize.OneTimes,
                Justify = JustifyMode.Center,
                PrintMode = PrintMode.FontA_12x24,
                Text = "Lo 1.4-1.5 Duong M14,KCN Tan Binh mo rong, TPHCM"
            });
            Lines.Add(new Line());
            Lines.Add(new Line());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private string[] ReadAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        private string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        private void WriteText(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        public bool IsConnectedToInternet(string host)
        {
            Ping p = new Ping();
            try
            {
                PingReply pr = p.Send(host, 3000);
                if (pr.Status == IPStatus.Success)
                {
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
