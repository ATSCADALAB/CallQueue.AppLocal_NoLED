using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CallQueue.Core;
// using ModbusRTUDriver;  // ← COMMENT - Không cần Modbus
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using CallQueue.AppLocal.Modules;

namespace CallQueue.AppLocal
{
    public partial class HomePage : DevExpress.XtraEditors.XtraUserControl
    {
        UnitOfWork unitOfWork;
        List<Service> services;
        List<Counter> counters;
        Dictionary<int, ServiceDashboard> serviceDashboardDictionary;
        Dictionary<int, CounterDashboard> counterDashboardDictionary;
        System.Threading.Timer timer;
        public BindingList<QueueModel> QueueHistory { get; set; }
        RealTimeSource realTimeSource;
        frmMain parent;

        public HomePage(UnitOfWork unitOfWork, frmMain parent)
        {
            InitializeComponent();
            this.unitOfWork = unitOfWork;
            this.parent = parent;
            services = unitOfWork.ServiceRepository.GetAll();
            counters = unitOfWork.CounterRepository.GetAll();

            serviceDashboardDictionary = new Dictionary<int, ServiceDashboard>();
            foreach (var item in services)
            {
                var dashBoard = CreateServiceDashboad(item);
                flpService.Controls.Add(dashBoard);
                serviceDashboardDictionary[item.Id] = dashBoard;
            }

            counterDashboardDictionary = new Dictionary<int, CounterDashboard>();
            foreach (var item in counters)
            {
                var dashBoard = CreateCounterDashboad(item);
                flpCounter.Controls.Add(dashBoard);
                counterDashboardDictionary[item.Id] = dashBoard;
            }

            QueueHistory = new BindingList<QueueModel>();
            realTimeSource = new RealTimeSource() { DataSource = QueueHistory };
            gridControl1.DataSource = realTimeSource;

            lueCounter.DataSource = counters;
            lueCounter.DisplayMember = "Name";
            lueCounter.ValueMember = "Id";
            lueCounter.ShowFooter = false;
            lueCounter.ShowHeader = false;
            lueCounter.PopulateColumns();
            beiCounter.EditValueChanged += BeiCounter_EditValueChanged;

            foreach (LookUpColumnInfo col in lueCounter.Columns)
            {
                if (col.FieldName != "Name")
                    col.Visible = false;
            }

            lbQuayDangChon.Caption = "Quầy đang chọn: ";
            timer = new System.Threading.Timer(Refresh, null, 100, 3000);
            Load += HomePage_Load;
        }

        private void BeiCounter_EditValueChanged(object sender, EventArgs e)
        {
            if (beiCounter.EditValue != null)
            {
                Counter counter = counters.FirstOrDefault(x => x.Id == int.Parse(beiCounter.EditValue.ToString()));
                if (counter != null)
                {
                    lbQuayDangChon.Caption = $"Quầy đang chọn: {counter.Name}";
                    return;
                }
            }
            lbQuayDangChon.Caption = "Quầy đang chọn: ";
        }

        // Tìm method Refresh() trong HomePage.cs và cập nhật phần này:
        private void Refresh(object state)
        {
            try
            {
                var servicesUpdate = unitOfWork.ServiceRepository.GetAll();
                foreach (var item in servicesUpdate)
                {
                    UpdateServiceDashboard(item, "000");
                }
                var queueModels = GetQueueModels();
                if (queueModels != null)
                {
                    for (int i = 0; i < queueModels.Count; i++)
                    {
                        var currentQueue = queueModels[i];
                        if (i <= QueueHistory.Count - 1)
                        {
                            var queueHistory = QueueHistory[i];
                            queueHistory.DateTime = currentQueue.DateTime;
                            queueHistory.ServiceName = currentQueue.ServiceName;
                            queueHistory.PrintedNumber = currentQueue.PrintedNumber;
                            queueHistory.Mark = currentQueue.Mark;
                            queueHistory.NumberFormat = currentQueue.NumberFormat;
                            queueHistory.Piority = currentQueue.Piority;
                            queueHistory.CustomerName = currentQueue.CustomerName; // Thêm dòng này
                            queueHistory.DisplayNumber = GetDisplayNumber(currentQueue.PrintedNumber, currentQueue.Mark, currentQueue.NumberFormat);
                        }
                        else
                        {
                            var queueHistory = new QueueModel();
                            queueHistory.DateTime = currentQueue.DateTime;
                            queueHistory.ServiceName = currentQueue.ServiceName;
                            queueHistory.PrintedNumber = currentQueue.PrintedNumber;
                            queueHistory.Mark = currentQueue.Mark;
                            queueHistory.NumberFormat = currentQueue.NumberFormat;
                            queueHistory.Piority = currentQueue.Piority;
                            queueHistory.CustomerName = currentQueue.CustomerName; // Thêm dòng này
                            queueHistory.DisplayNumber = GetDisplayNumber(currentQueue.PrintedNumber, currentQueue.Mark, currentQueue.NumberFormat);
                            QueueHistory.Add(queueHistory);
                        }
                    }

                    if (queueModels.Count < QueueHistory.Count)
                    {
                        int count = QueueHistory.Count;
                        for (int i = queueModels.Count; i < count; i++)
                        {
                            QueueHistory.RemoveAt(i);
                        }
                    }
                }
            }
            catch
            {

            }
            finally { }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
            finally { }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
        }

        public void UpdateServiceDashboard(Service service, string numberFormat)
        {
            if (serviceDashboardDictionary.ContainsKey(service.Id))
            {
                serviceDashboardDictionary[service.Id].UpdateDashboard(service, numberFormat);
            }
        }

        public void UpdateCounterDashboard(QueueInfor queueInfor)
        {
            if (counterDashboardDictionary.ContainsKey(queueInfor.CounterId))
            {
                counterDashboardDictionary[queueInfor.CounterId].UpdateDashboard(queueInfor);
            }
        }

        public void UpdateCounterDashboard(int counterId, string displayNumber)
        {
            if (counterDashboardDictionary.ContainsKey(counterId))
            {
                counterDashboardDictionary[counterId].UpdateDashboard(counterId, displayNumber);
            }
        }

        private CounterDashboard CreateCounterDashboad(Counter counter)
        {
            return new CounterDashboard(counter, unitOfWork);
        }

        private ServiceDashboard CreateServiceDashboad(Service service)
        {
            return new ServiceDashboard(service);
        }

        public string GetDisplayNumber(QueueInfor queue)
        {
            string number = queue.Number.ToString();
            if (!string.IsNullOrEmpty(queue.NumberFormat))
                number = queue.Number.ToString(queue.NumberFormat);
            number = number.Insert(0, queue.Mark);
            return number;
        }

        public List<QueueModel> GetQueueModels()
        {
            List<QueueModel> queueModels = new List<QueueModel>();
            try
            {
                // Query đã sửa: PiorityLevel từ service, NumberFormat từ common, bỏ s.NumberFormat
                string query = @"
            SELECT q.DateTime, s.Name as ServiceName, s.PiorityLevel as Piority, s.Mark, 
                   com.NumberFormat,
                   q.Number as PrintedNumber, 
                   COALESCE(q.customername, '') as CustomerName
            FROM queue q 
            INNER JOIN service s ON q.ServiceId = s.Id 
            CROSS JOIN common com
            ORDER BY q.DateTime DESC 
            LIMIT 50";

                DataTable dt = unitOfWork.SQLHelper.ExecuteQuery(query);
                if (dt != null)
                {
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        QueueModel queueModel = new QueueModel();
                        queueModel.DateTime = Convert.ToDateTime(dtRow["DateTime"]).ToString("dd/MM/yyyy HH:mm:ss");
                        queueModel.ServiceName = dtRow["ServiceName"].ToString();
                        queueModel.Piority = dtRow["Piority"].ToString();
                        queueModel.Mark = dtRow["Mark"].ToString();
                        queueModel.NumberFormat = dtRow["NumberFormat"].ToString(); // Từ bảng common
                        queueModel.PrintedNumber = int.Parse(dtRow["PrintedNumber"].ToString());
                        queueModel.CustomerName = dtRow["CustomerName"].ToString();
                        queueModels.Add(queueModel);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return queueModels;
        }

        public string GetDisplayNumber(int printedNumber, string mark, string numberFomat)
        {
            string number = printedNumber.ToString();
            if (!string.IsNullOrEmpty(numberFomat))
                number = printedNumber.ToString(numberFomat);
            number = number.Insert(0, mark);
            return number;
        }

        private void btnPiorityCall_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (beiCounter.EditValue != null)
                {
                    int counterId = Convert.ToInt32(beiCounter.EditValue);
                    if (!parent.counterCallBlockDictionary.ContainsKey(counterId))
                        parent.counterCallBlockDictionary[counterId] = false;

                    bool isBlock = parent.counterCallBlockDictionary[counterId];

                    if (isBlock)
                    {
                        if (parent.callVoice.IsPlaying)
                        {
                            Utils.ShowInformation("Hệ thống gọi đang bận xin hảy thử lại sau !");
                            return;
                        }
                        else
                            isBlock = false;
                    }

                    frmSelectPiorityNumber frm = new frmSelectPiorityNumber();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        parent.CallPiority(counterId, frm.PiorityNumber);

                        Console.WriteLine($"✅ Đã gọi ưu tiên số {frm.PiorityNumber} tại quầy {counterId}");
                    }
                }
                else
                {
                    Utils.ShowExclamation("Xin mời chọn quầy để gọi !");
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }

        private void btnCallPrevious_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (beiCounter.EditValue != null)
                {
                    int counterId = Convert.ToInt32(beiCounter.EditValue);
                    if (!parent.counterCallBlockDictionary.ContainsKey(counterId))
                        parent.counterCallBlockDictionary[counterId] = false;

                    bool isBlock = parent.counterCallBlockDictionary[counterId];

                    if (isBlock)
                    {
                        if (parent.callVoice.IsPlaying)
                        {
                            Utils.ShowInformation("Hệ thống gọi đang bận xin hảy thử lại sau !");
                            return;
                        }
                        else
                            isBlock = false;
                    }


                    if (parent.CallPrevious(counterId))
                    {

                        Console.WriteLine($"✅ Đã gọi lui tại quầy {counterId}");
                    }
                }
                else
                {
                    Utils.ShowExclamation("Xin mời chọn quầy để gọi !");
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }

        private void btnCallNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (beiCounter.EditValue != null)
                {
                    int counterId = Convert.ToInt32(beiCounter.EditValue);
                    if (!parent.counterCallBlockDictionary.ContainsKey(counterId))
                        parent.counterCallBlockDictionary[counterId] = false;

                    bool isBlock = parent.counterCallBlockDictionary[counterId];

                    if (isBlock)
                    {
                        if (parent.callVoice.IsPlaying)
                        {
                            Utils.ShowInformation("Hệ thống gọi đang bận xin hảy thử lại sau !");
                            return;
                        }
                        else
                        {
                            parent.counterCallBlockDictionary[counterId] = false;
                            isBlock = false;
                        }
                    }



                    if (parent.CallNext(counterId))
                    {
                        Console.WriteLine($"✅ Đã gọi số tiếp theo tại quầy {counterId}");
                    }
                }
                else
                {
                    Utils.ShowExclamation("Xin mời chọn quầy để gọi !");
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }

        private void btnCallAgain_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (beiCounter.EditValue != null)
                {
                    int counterId = Convert.ToInt32(beiCounter.EditValue);
                    if (!parent.counterCallBlockDictionary.ContainsKey(counterId))
                        parent.counterCallBlockDictionary[counterId] = false;

                    bool isBlock = parent.counterCallBlockDictionary[counterId];

                    if (isBlock)
                    {
                        if (parent.callVoice.IsPlaying)
                        {
                            Utils.ShowInformation("Hệ thống gọi đang bận xin hảy thử lại sau !");
                            return;
                        }
                        else
                            isBlock = false;
                    }

                    if (parent.CallAgain(counterId))
                    {
                        Console.WriteLine($"✅ Đã gọi lại tại quầy {counterId}");
                    }
                }
                else
                {
                    Utils.ShowExclamation("Xin mời chọn quầy để gọi !");
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }

        public void CallManual(int counterId, string callNumber)
        {
            try
            {
                var counter = unitOfWork.CounterRepository.GetByPrimaryKey(counterId);
                if (counter != null && counter.Id != 0)
                {
                    bool isBlock = false;
                    if (!parent.counterCallBlockDictionary.ContainsKey(counterId))
                        parent.counterCallBlockDictionary[counterId] = false;
                    else
                        isBlock = parent.counterCallBlockDictionary[counterId];

                    if (isBlock)
                        return;

                    string callVoiceContent = parent.voiceManager.GetVoiceParameter().CallVoiceContent;
                    string voiceString = string.Format(callVoiceContent, callNumber, counter.Voice);
                    parent.callVoice.Content = voiceString;
                    parent.counterCallBlockDictionary[counterId] = true;

                    unitOfWork.SQLHelper.ExecuteNonQuery($"update counter set LCDDisplay = '{callNumber}' where Id = {counterId}");

                    Debug.WriteLine($"Call {voiceString} - Counter {callVoiceContent} - {voiceString}");
                    parent.callVoice.PlayAsync(voiceString, () =>
                    {
                        Debug.WriteLine($"Call Finish: {voiceString} - Counter {callVoiceContent} - {voiceString}");
                        parent.counterCallBlockDictionary[counterId] = false;
                    });
                }
            }
            catch { }
        }

        private void btnSelectCounter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSelectCounter frm = new frmSelectCounter(counters, beiCounter.EditValue);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.beiCounter.EditValue = frm.SelectedValue;
            }
        }
        private void btnResetCounter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (beiCounter.EditValue != null)
                {
                    int counterId = Convert.ToInt32(beiCounter.EditValue);
                    parent.Reset1(counterId);
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                ex.ShowErrorMessageBox();
            }
        }
        private void btnRegisterCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                frmCustomerRegistration frm = new frmCustomerRegistration();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Lấy QueueManager từ IoC Container
                    var queueManager = IoC.Instance.Get<QueueManager>();

                    // Đăng ký khách hàng
                    var result = queueManager.RegisterCustomer(frm.CustomerName, 1);

                    if (result.Success)
                    {
                        string message = $"Đăng ký thành công!\n\n" +
                                       $"Khách hàng: {result.CustomerName}\n" +
                                       $"Số thứ tự: {result.QueueNumber:1000}\n\n" +
                                       $"Vui lòng chờ được gọi!";

                        MessageBox.Show(message, "Đăng Ký Thành Công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshQueueDisplay();
                        parent.OnCustomerRegistered(result.CustomerName, result.QueueNumber, 1);
                        Console.WriteLine($"✅ Đăng ký thành công: {result.CustomerName} - Số {result.QueueNumber}");
                    }
                    else
                    {
                        MessageBox.Show(result.Message, "Lỗi Đăng Ký",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi Hệ Thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"❌ Lỗi đăng ký khách hàng: {ex}");
            }
        }

        /// <summary>
        /// Refresh danh sách hàng chờ sau khi đăng ký
        /// </summary>
        private void RefreshQueueDisplay()
        {
            try
            {
                // Cập nhật lại danh sách hiển thị bằng cách gọi lại method Refresh
                var queueModels = GetQueueModels();
                if (queueModels != null)
                {
                    // Cập nhật QueueHistory hiện tại
                    for (int i = 0; i < queueModels.Count; i++)
                    {
                        var currentQueue = queueModels[i];
                        if (i <= QueueHistory.Count - 1)
                        {
                            var queueHistory = QueueHistory[i];
                            queueHistory.DateTime = currentQueue.DateTime;
                            queueHistory.ServiceName = currentQueue.ServiceName;
                            queueHistory.PrintedNumber = currentQueue.PrintedNumber;
                            queueHistory.Mark = currentQueue.Mark;
                            queueHistory.NumberFormat = currentQueue.NumberFormat;
                            queueHistory.Piority = currentQueue.Piority;
                            queueHistory.CustomerName = currentQueue.CustomerName; // Thêm dòng này
                            queueHistory.DisplayNumber = GetDisplayNumber(currentQueue.PrintedNumber, currentQueue.Mark, currentQueue.NumberFormat);
                        }
                        else
                        {
                            var queueHistory = new QueueModel();
                            queueHistory.DateTime = currentQueue.DateTime;
                            queueHistory.ServiceName = currentQueue.ServiceName;
                            queueHistory.PrintedNumber = currentQueue.PrintedNumber;
                            queueHistory.Mark = currentQueue.Mark;
                            queueHistory.NumberFormat = currentQueue.NumberFormat;
                            queueHistory.Piority = currentQueue.Piority;
                            queueHistory.CustomerName = currentQueue.CustomerName; // Thêm dòng này
                            queueHistory.DisplayNumber = GetDisplayNumber(currentQueue.PrintedNumber, currentQueue.Mark, currentQueue.NumberFormat);
                            QueueHistory.Add(queueHistory);
                        }
                    }

                    // Xóa các items thừa nếu có
                    if (queueModels.Count < QueueHistory.Count)
                    {
                        int count = QueueHistory.Count;
                        for (int i = queueModels.Count; i < count; i++)
                        {
                            QueueHistory.RemoveAt(queueModels.Count);
                        }
                    }
                }

                // Cập nhật counter nếu có
                if (beiCounter.EditValue != null)
                {
                    int counterId = Convert.ToInt32(beiCounter.EditValue);
                    parent.DisplayCurrentQueueToHomePage(counterId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ Lỗi refresh queue display: {ex}");
            }
        }
        
    }
}
public class QueueModel : INotifyPropertyChanged
    {
        string dateTime;
        string serviceName;
        int printedNumber;
        string piority;
        string mark;
        string numberFormat;
        string displayNumber;
        string customerName; // Thêm field này

        public string DisplayNumber
        {
            get { return displayNumber; }
            set
            {
                if (value != displayNumber)
                {
                    displayNumber = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string DateTime
        {
            get { return dateTime; }
            set
            {
                if (value != dateTime)
                {
                    dateTime = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ServiceName
        {
            get { return serviceName; }
            set
            {
                if (value != serviceName)
                {
                    serviceName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int PrintedNumber
        {
            get { return printedNumber; }
            set
            {
                if (value != printedNumber)
                {
                    printedNumber = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Piority
        {
            get { return piority; }
            set
            {
                if (value != piority)
                {
                    piority = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Mark
        {
            get { return mark; }
            set
            {
                if (value != mark)
                {
                    mark = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string NumberFormat
        {
            get { return numberFormat; }
            set
            {
                if (value != numberFormat)
                {
                    numberFormat = value;
                    RaisePropertyChanged();
                }
            }
        }

        // ===== THÊM PROPERTY CustomerName =====
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if (value != customerName)
                {
                    customerName = value;
                    RaisePropertyChanged();
                }
            }
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }