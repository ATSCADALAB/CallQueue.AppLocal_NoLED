using System;
using System.ComponentModel;
using System.Text;
using System.IO.Ports;

namespace CallQueue.PrintController
{
    public partial class SerialPrinter : Component
    {
        #region Public members

        public string Port { get; set; } = "/dev/ttyUSB0";
        public Parity Parity { get; set; } = Parity.None;
        public StopBits StopBits { get; set; } = StopBits.One;
        public int DataBits { get; set; } = 8;
        public int BaudRate { get; set; } = 19200;

        #endregion

        #region Private members

        SerialPort serial;
        char[] cutPaperFrame = new char[] { GS, 'V', Convert.ToChar(65), Convert.ToChar(1) };
        const char ESC = (char)27;
        const char GS = (char)29;

        #endregion

        #region Constructors

        public SerialPrinter()
        {
            InitializeComponent();
        }

        public SerialPrinter(IContainer container) : base()
        {
            container.Add(this);
        }

        #endregion

        #region Public methods

        public bool Open()
        {
            try
            {
                serial = new SerialPort(Port, BaudRate, Parity, DataBits, StopBits);
                serial.Open();
                Console.WriteLine($"Open {serial.PortName} success.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Open {serial.PortName} fail.");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                serial.Close();
                Console.WriteLine($"Close {serial.PortName} success.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Close {serial.PortName} fail.");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Set font size
        /// </summary>
        /// <param name="size">The range is 0 - 255</param>
        /// <returns></returns>
        public bool SetFontSize(byte size)
        {
            try
            {
                char[] setFontSizeFrame = new char[] { GS, '!', Convert.ToChar(size) };
                byte[] frame = Encoding.ASCII.GetBytes(setFontSizeFrame);
                serial.Write(frame, 0, frame.Length);
                Console.WriteLine($"Set font size : {size}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error set font size: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// |----------------------------------------------------------|
        /// | 0 |  Off | 00 | 0   | Character font A (12x24)           |
        /// |   |  On  | 01 | 1   | Character font B(9x24)             |
        /// |----------------------------------------------------------|
        /// | 1 |  -   | -  | -   | Undefined.                         |
        /// |----------------------------------------------------------|
        /// | 2 |  -   | -  | -   | Undefined.                         |
        /// |----------------------------------------------------------|
        /// | 3 |  Off | 00 | 0   | Emphasized mode not selected.      |
        /// |   |  On  | 08 | 8   | Emphasized mode selected.          |
        /// |----------------------------------------------------------|
        /// | 4 |  Off | 00 | 0   | Double-height mode not selected.   |
        /// |   |  On  | 10 | 16  | Double-height mode selected.       |
        /// |----------------------------------------------------------|
        /// | 5 |  Off | 00 | 0   | Double-width mode not selected.    |
        /// |   |  On  | 20 | 32  | Double-width mode selected.        |
        /// |----------------------------------------------------------|
        /// | 6 |  -   | -  | -   | Undefined.                         |
        /// |----------------------------------------------------------|
        /// | 7 |  Off | 00 | 0   | Underline mode not selected.       |
        /// |   |  On  | 80 | 128 | Underline mode selected.           |
        /// |----------------------------------------------------------|  
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool SetPrintMode(byte mode)
        {
            try
            {                                                
                char[] setFontFormatFrame = new char[] { Convert.ToChar(27), '!', Convert.ToChar(mode) };
                byte[] frame = Encoding.ASCII.GetBytes(setFontFormatFrame);
                serial.Write(frame, 0, frame.Length);
                Console.WriteLine($"Set font format : {mode}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error set font size: {ex.Message}");
                return false;
            }
        }

        public bool CutPaper()
        {
            try
            { 
                byte[] frame = Encoding.ASCII.GetBytes(cutPaperFrame);
                serial.Write(frame, 0, frame.Length);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error cut paper: {ex.Message}");
                return false;
            }
        }

        public bool Justify(byte mode)
        {
            try
            {
                char[] setFontSizeFrame = new char[] { ESC, 'a', Convert.ToChar(mode) };
                byte[] frame = Encoding.ASCII.GetBytes(setFontSizeFrame);
                serial.Write(frame, 0, frame.Length);
                Console.WriteLine($"Justify to : {mode.ToString()}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when set justify: {ex.Message}");
                return false;
            }
        }

        public bool WriteLine(string text)
        {
            try
            {
                serial.WriteLine(text);
                Console.WriteLine($"Write: {text}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error write text: {ex.Message}");
                return false;
            }
        }

        #endregion
    }
}
