using System;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using System.Diagnostics;
using CallQueue.Core;
using System.Reflection;
using System.IO;
using DevExpress.XtraReports.UI;
using System.Xml;
using System.Collections.Generic;
using CallQueue.Controls;
using System.Linq;
using System.Threading;
using CallQueue.AppLocal.WebSocket;

namespace CallQueue.AppLocal
{
    public partial class frmMain : RibbonForm
    {
        #region Private members
        private Process appProcess;
        private readonly string phanMemPath = Application.StartupPath;
        private string tssPath = Path.Combine(Application.StartupPath, "tts");
        private string serverLockPath = Path.Combine(Application.StartupPath, "tts", "server.lock");
        private string appExePath = Path.Combine(Application.StartupPath, "tts", "TTS-Service-http.exe");
        private UserControl currentPage;
        QueueManager queueManager;
        PrinterManager printerSetting;
        public VoiceManager voiceManager;
        UnitOfWork unitOfWork;
        public VoiceParameter voiceParameter;
        public CallVoice callVoice;
        private QueueWebSocketIntegration _webSocketIntegration;
        private readonly DateTime expirationDate = new DateTime(2025,8 , 1);
        public Dictionary<int, QueueInfor> counterToCurrentQueueDictionary = new Dictionary<int, QueueInfor>();
        public Dictionary<int, bool> counterCallBlockDictionary = new Dictionary<int, bool>();
        #endregion

        #region Pages

        HomePage homePage;
        CallVoiceSetting voiceSettingPage;
        AccountPage accountPage;
        RolePage rolePage;
        ServicePage servicePage;
        CounterPage counterPage;
        ReportByTime callHistoryPage;

        #endregion

        #region Constructors

        public frmMain()
        {
            InitializeComponent();
            if (CheckExpirationDate())
            {
                
                callVoice = new CallVoice();
                unitOfWork = IoC.Instance.Get<UnitOfWork>();
                queueManager = IoC.Instance.Get<QueueManager>();
                printerSetting = IoC.Instance.Get<PrinterManager>();
                voiceManager = IoC.Instance.Get<VoiceManager>();
                IoC.Instance.Kernal.Bind<CallVoice>().ToConstant(callVoice);
                Load += FrmMain_Load;
                InitializeWebSocket();
                InitializeTTS();
            }    
            
        }
        private bool CheckExpirationDate()
        {
            if (DateTime.Now > expirationDate)
            {
                MessageBox.Show(
                    $"Ứng dụng đã hết hạn sử dụng vào ngày {expirationDate:dd/MM/yyyy}. Ứng dụng sẽ thoát.",
                    "Hết Hạn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Application.Exit();
                return false;

            }
            else
            {
                return true;
            }    
        }
        private void InitializeTTS()
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("TTS-Service-http");
                if (processes.Length > 0)
                {
                    // app.exe đã chạy, lưu tiến trình đầu tiên để quản lý khi đóng
                    appProcess = processes[0];
                    //MessageBox.Show("app.exe đã được mở, không cần mở lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Kiểm tra thư mục tss
                if (!Directory.Exists(tssPath))
                {
                    MessageBox.Show("Thư mục tss không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra và xóa file server.lock nếu tồn tại
                if (File.Exists(serverLockPath))
                {
                    try
                    {
                        File.Delete(serverLockPath);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Không thể xóa file server.lock: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Kiểm tra và chạy app.exe
                if (File.Exists(appExePath))
                {
                    try
                    {
                        appProcess = new Process();
                        appProcess.StartInfo.FileName = appExePath;
                        appProcess.StartInfo.WorkingDirectory = tssPath; // Thiết lập thư mục làm việc là thư mục phanmem
                        appProcess.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể khởi động app.exe: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("File app.exe không tồn tại trong thư mục phanmem.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializeWebSocket()
        {
            try
            {
                Console.WriteLine("🚀 Đang khởi tạo WebSocket integration...");

                _webSocketIntegration = new QueueWebSocketIntegration(queueManager,8080);

                // Subscribe tới events
                _webSocketIntegration.OnTestVoiceRequested += () =>
                {
                };

                _webSocketIntegration.OnClientConnected += (clientInfo) =>
                {
                    var message = string.Format("✅ Web client kết nối: {0} từ {1}",
                        clientInfo.Id, clientInfo.RemoteEndPoint);
                    Console.WriteLine(message);
                };

                _webSocketIntegration.OnClientDisconnected += (clientInfo) =>
                {
                    var message = string.Format("❌ Web client ngắt kết nối: {0}", clientInfo.Id);
                    Console.WriteLine(message);
                };

                // Khởi tạo WebSocket
                if (_webSocketIntegration.Initialize())
                {
                    Console.WriteLine("✅ WebSocket integration khởi tạo thành công!");
                    Console.WriteLine("🌐 Web clients có thể kết nối tại: ws://localhost:8080");
                }
                else
                {
                    Console.WriteLine("❌ Không thể khởi tạo WebSocket integration");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Lỗi khởi tạo WebSocket: " + ex.Message);
                Debug.WriteLine("WebSocket initialization error: " + ex.ToString());
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Reset();

            voiceParameter = voiceManager.GetVoiceParameter();
            callVoice.AllowPlayStartSound = voiceParameter.AllowPlayStartSound;
            callVoice.Enabled = voiceParameter.Enabled;
            NavigateToAsync(() =>
            {
                if (homePage == null)
                    homePage = new HomePage(unitOfWork, this);
                return homePage;
            });


            foreach (var counter in unitOfWork.CounterRepository.GetAll())
            {
                DisplayCurrentQueueToHomePage(counter.Id);
            }
        }

        #endregion

        #region Modbus tags - COMMENT TOÀN BỘ REGION

        #endregion

        #region Private methods

        private void NavigateToAsync<T>(Func<T> funcControl, Action callback = null)
            where T : UserControl
        {
            try
            {
                if (funcControl != null)
                {
                    if (typeof(T) != currentPage?.GetType() || currentPage == null)
                    {
                        Enabled = false;
                        transitionManager.StartTransition(containerControl);
                        Debug.WriteLine(DateTime.Now.ToString());
                        funcControl.BeginInvoke((IAsyncResult result) =>
                        {
                            currentPage = result.AsyncState as T;
                            if (currentPage is HomePage homePage)
                            {
                                foreach (var item in containerControl.Controls)
                                {
                                    if (item == homePage)
                                    {
                                        ribbonControl1.SetCrossThread(x => x.UnMergeRibbon());
                                        var tras = transitionManager.Transitions[containerControl];
                                        if (currentPage.Controls["ribbonControl1"] is RibbonControl ribbon)
                                            ribbonControl1.SetCrossThread(x => x.MergeRibbon(ribbon));
                                        if (currentPage.Controls["ribbonStatusBar1"] is RibbonStatusBar statusBar)
                                            ribbonStatusBar1.SetCrossThread(x => x.MergeStatusBar(statusBar));
                                        currentPage.SetCrossThread(x => x.BringToFront());
                                        this.SetCrossThread(x => x.Enabled = true);
                                        this.SetCrossThread(x => transitionManager.EndTransition());
                                        Debug.WriteLine(DateTime.Now.ToString());
                                        callback?.Invoke();
                                        return;
                                    }
                                }
                            }
                            var transition = transitionManager.Transitions[containerControl];
                            if (currentPage.Controls["ribbonControl1"] is RibbonControl mergeRibbon)
                                ribbonControl1.SetCrossThread(x => x.MergeRibbon(mergeRibbon));
                            if (currentPage.Controls["ribbonStatusBar1"] is RibbonStatusBar statusBar2)
                                ribbonStatusBar1.SetCrossThread(x => x.MergeStatusBar(statusBar2));
                            containerControl.SetCrossThread(x =>
                            {
                                List<object> needRemove = new List<object>();
                                foreach (var control in containerControl.Controls)
                                {
                                    if (!(control is HomePage))
                                        needRemove.Add(control);
                                    else
                                    {
                                        (control as UserControl).SetCrossThread(q => q.SendToBack());
                                    }
                                }
                                needRemove.ForEach(c => containerControl.Controls.Remove(c as Control));
                            });
                            currentPage.Dock = DockStyle.Fill;
                            currentPage.Load += (s, e) =>
                            {
                                transitionManager.EndTransition();
                            };
                            containerControl.SetCrossThread(x => x.Controls.Add(currentPage));
                            currentPage.SetCrossThread(x => x.BringToFront());

                            this.SetCrossThread(x => x.Enabled = true);
                            Debug.WriteLine(DateTime.Now.ToString());
                            callback?.Invoke();

                        }, funcControl.Invoke());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void OpenFormAsync<T>(Func<T> funcForm, Action callback = null)
            where T : Form
        {
            if (funcForm != null)
            {
                if (typeof(T) != currentPage?.GetType() || currentPage == null)
                {
                    Enabled = false;
                    transitionManager.StartTransition(containerControl);
                    Debug.WriteLine(DateTime.Now.ToString());
                    var asyncResult = funcForm.BeginInvoke((IAsyncResult result) =>
                    {
                        this.SetCrossThread(x => x.Enabled = true);
                        Debug.WriteLine(DateTime.Now.ToString());
                    }, funcForm.Invoke());
                    transitionManager.EndTransition();
                    (asyncResult.AsyncState as T).ShowDialog();
                    callback?.Invoke();
                }
            }
        }

        #endregion

        #region Navigation button click event handler

        private void aceHome_Click(object sender, EventArgs e)
        {
            NavigateToAsync(() =>
            {
                return homePage;
            });
        }

        private void aceCallhistory_Click(object sender, EventArgs e)
        {
            NavigateToAsync(() =>
            {
                callHistoryPage = new ReportByTime(unitOfWork);
                return callHistoryPage;
            });
        }

        private void aceVoiceContent_Click(object sender, EventArgs e)
        {
            NavigateToAsync(() =>
            {
                voiceSettingPage = new CallVoiceSetting(callVoice, voiceManager);
                return voiceSettingPage;
            }, () => voiceParameter = voiceManager.GetVoiceParameter());
        }

        private void acePrintContent_Click(object sender, EventArgs e)
        {
            NavigateToAsync(() =>
            {
                return new ReportSettingPage(unitOfWork, printerSetting);
            });
        }

        private void aceUser_Click(object sender, EventArgs e)
        {
            NavigateToAsync(() =>
            {
                accountPage = new AccountPage(unitOfWork);
                return accountPage;
            });
        }

        private void aceRole_Click(object sender, EventArgs e)
        {
            NavigateToAsync(() =>
            {
                rolePage = new RolePage();
                return rolePage;
            });
        }

        private void aceConfig_Click(object sender, EventArgs e)
        {

        }

        private void aceService_Click(object sender, EventArgs e)
        {
            NavigateToAsync(() =>
            {
                servicePage = new ServicePage(unitOfWork);
                return servicePage;
            });
        }

        private void aceCounter_Click(object sender, EventArgs e)
        {
            NavigateToAsync(() =>
            {
                counterPage = new CounterPage(unitOfWork);
                return counterPage;
            });
        }

        #endregion

        #region Call Queue

        public bool CallNext(int counterId)
        {
            try
            {
                if (queueManager.CanCallNext(counterId, out QueueInfor currentQueue))
                {
                    counterToCurrentQueueDictionary[counterId] = currentQueue;
                    DisplayCurrentQueueToHomePage(counterId);
                    //CallVoice(currentQueue);  // ← Bật lại CallVoice
                    NotifyWebSocketCallNext(counterId, currentQueue);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                _webSocketIntegration?.NotifyError("Lỗi gọi số tiếp theo: " + ex.Message, counterId);
                return false;
            }
        }

        public bool CallPrevious(int counterId)
        {
            try
            {
                QueueInfor currentQueue = null;

                if (counterToCurrentQueueDictionary.ContainsKey(counterId))
                {
                    currentQueue = counterToCurrentQueueDictionary[counterId];
                }
                else
                {
                    currentQueue = queueManager.GetLastCalledQueueInfor(counterId);
                }

                if (currentQueue.Id != 0)
                {
                    if (queueManager.CanCallPrevious(counterId, currentQueue.Number, out currentQueue))
                    {
                        counterToCurrentQueueDictionary[counterId] = currentQueue;
                        //CallVoice(currentQueue);  // ← Bật lại CallVoice
                        DisplayCurrentQueueToHomePage(counterId);
                        NotifyWebSocketCallPrevious(counterId, currentQueue);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                _webSocketIntegration?.NotifyError("Lỗi gọi lui: " + ex.Message, counterId);
                return false;
            }
        }

        public void CallPiority(int counterId, int number)
        {
            try
            {
                QueueInfor currentQueue = null;
                // ===== GIỚI HẠN VÀ FORMAT SỐ ƯU TIÊN =====
                int limitedNumber = number > 1000 ? 999 : number;
                string priorityDisplayNumber = "P1" + limitedNumber.ToString().PadLeft(3, '0');

                // ===== CẬP NHẬT GIAO DIỆN =====
                homePage?.UpdateCounterDashboard(counterId, priorityDisplayNumber);
                NotifyWebSocketCallPriority(counterId, currentQueue, 1000+int.Parse(limitedNumber.ToString().PadLeft(3, '0')));

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                _webSocketIntegration?.NotifyError("Lỗi gọi ưu tiên: " + ex.Message, counterId);
            }
        }

        public bool CallAgain(int counterId)
        {
            try
            {
                QueueInfor currentQueue = null;

                if (counterToCurrentQueueDictionary.ContainsKey(counterId))
                {
                    currentQueue = counterToCurrentQueueDictionary[counterId];
                }
                else
                {
                    currentQueue = queueManager.GetLastCalledQueueInfor(counterId);
                }

                if (currentQueue.Id != 0)
                {
                    //CallVoice(currentQueue);  // ← Bật lại CallVoice
                    NotifyWebSocketCallAgain(counterId, currentQueue);
                    DisplayCurrentQueueToHomePage(counterId);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                _webSocketIntegration?.NotifyError("Lỗi gọi lại: " + ex.Message, counterId);
                return false;
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
                    if (!counterCallBlockDictionary.ContainsKey(counterId))
                        counterCallBlockDictionary[counterId] = false;
                    else
                        isBlock = counterCallBlockDictionary[counterId];

                    if (isBlock)
                        return;

                    string callVoiceContent = voiceManager.GetVoiceParameter().CallVoiceContent;
                    string voiceString = string.Format(callVoiceContent, callNumber, counter.Voice);
                    callVoice.Content = voiceString;
                    counterCallBlockDictionary[counterId] = true;
                    unitOfWork.SQLHelper.ExecuteNonQuery($"update counter set LCDDisplay = '{callNumber}' where Id = {counterId}");
                    Debug.WriteLine($"Call {voiceString} - Counter {callVoiceContent} - {voiceString}");
                    callVoice.PlayAsync(voiceString, () =>
                    {
                        Debug.WriteLine($"Call Finish: {voiceString} - Counter {callVoiceContent} - {voiceString}");
                        counterCallBlockDictionary[counterId] = false;
                    });
                }
            }
            catch { }
        }

        public void Reset()
        {
            try
            {
                printerSetting.Reset();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void Reset1(int counterId)
        {
            try
            {
                printerSetting.Reset_1(counterId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public void CallVoice(QueueInfor queueInfor)
        {
            if (queueInfor.Id != 0 && queueInfor.Number != 0 && queueInfor.CounterId != 0 && queueInfor.ServiceId != 0)
            {
                bool isBlock = false;
                if (!counterCallBlockDictionary.ContainsKey(queueInfor.CounterId))
                    counterCallBlockDictionary[queueInfor.CounterId] = false;
                else
                    isBlock = counterCallBlockDictionary[queueInfor.CounterId];

                if (isBlock)
                    return;

                string number = GetDisplayNumber(queueInfor);

                string voiceString = string.Format(queueInfor.CallVoiceContent, number, queueInfor.CounterVoice);
                counterCallBlockDictionary[queueInfor.CounterId] = true;
                Debug.WriteLine($"Call {number} - Counter {queueInfor.CounterVoice} - {voiceString}");
                callVoice.PlayAsync(voiceString, () =>
                {
                    Debug.WriteLine($"Call Finish: {queueInfor.Number} - Counter {queueInfor.CounterVoice} - {voiceString}");
                    counterCallBlockDictionary[queueInfor.CounterId] = false;
                });
            }
        }

        #endregion

        #region Read modbus - COMMENT TOÀN BỘ REGION

        /*
        public void InitModbus()
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        private void AddressDisplayLedNumberTag_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        private void AddressDisplayLedNumberTag_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        private void RemainNumberTag_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        private void ResetTagInFirstLoad(object sender, StatusChangedEventArgs e)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        private void PiorityNumberTag_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        private void PiorityNumberTag_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        private void CallCommandTag_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        private void CallCommandTag_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        private Address BuildAddress(int address, byte deviceId)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        public void DisplayCurrentQueueNumber(int counterId, ITag displayKeyBoardTag, ITag displayLedTag, ITag displayLedMode)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        public void DisplayPiorityNumberToHompage(int counterId, string displayNumber, ITag displayLedTag)
        {
            // Comment toàn bộ method này - không cần Modbus
        }

        public void UpdateCountRemainQueue()
        {
            // Comment toàn bộ method này - không cần Modbus
        }
        */

        #endregion

        public string GetDisplayNumber(QueueInfor queue)
        {
            string number = queue.Number.ToString();
            if (!string.IsNullOrEmpty(queue.NumberFormat))
                number = queue.Number.ToString(queue.NumberFormat);
            number = number.Insert(0, queue.Mark);
            return number;
        }

        public void DisplayCurrentQueueToHomePage(int counterId)
        {
            try
            {
                if (counterToCurrentQueueDictionary.ContainsKey(counterId))
                {
                    QueueInfor currentQueue = counterToCurrentQueueDictionary[counterId];
                    if (currentQueue.CounterId != 0)
                    {
                        homePage?.UpdateCounterDashboard(currentQueue);
                    }
                }
                else
                {
                    var currentQueue = queueManager.GetLastCalledQueueInfor(counterId);
                    if (currentQueue.CounterId == counterId)
                    {
                        counterToCurrentQueueDictionary[counterId] = currentQueue;
                        homePage?.UpdateCounterDashboard(currentQueue);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void btnQuickAccessHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            aceHome_Click(null, null);
        }

        #region WebSocket Notification Methods
        /// <summary>
        /// Thông báo khi có khách hàng đăng ký mới
        /// Gọi method này khi đăng ký thành công
        /// </summary>
        public void OnCustomerRegistered(string customerName, int queueNumber, int serviceId)
        {
            try
            {
                _webSocketIntegration?.NotifyNewCustomerRegistered(customerName, queueNumber, serviceId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi thông báo đăng ký mới: {ex.Message}");
            }
        }
        private void NotifyWebSocketCallNext(int counterId, QueueInfor queueInfo)
        {
            try
            {
                if (queueInfo == null)
                {
                    Debug.WriteLine("WebSocket notification error (CallNext): queueInfo is null");
                    _webSocketIntegration?.NotifyError("Không có thông tin queue để gọi", counterId);
                    return;
                }

                var counter = GetCounterInfo(counterId);
                var service = GetServiceInfo(queueInfo.ServiceId);

                _webSocketIntegration?.NotifyCallNext(
                    counterId: counterId,
                    counterName: counter?.Name ?? string.Format("Quầy {0}", counterId),
                    currentNumber: queueInfo.Number,
                    serviceName: service?.Name ?? "Unknown Service",
                    customerName: queueInfo.CustomerName,
                    displayNumber: GetDisplayNumber(queueInfo) ?? queueInfo.Number.ToString().PadLeft(3, '0')
                   
                );

                Console.WriteLine(string.Format("📤 Đã gửi CallNext: {0} tại {1}",
                    queueInfo.Number, counter?.Name ?? string.Format("Quầy {0}", counterId)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("WebSocket notification error (CallNext): " + ex.Message);
                _webSocketIntegration?.NotifyError("Lỗi gửi thông báo CallNext: " + ex.Message, counterId);
            }
        }

        private void NotifyWebSocketCallPrevious(int counterId, QueueInfor queueInfo)
        {
            try
            {
                if (queueInfo == null)
                {
                    Debug.WriteLine("WebSocket notification error (CallPrevious): queueInfo is null");
                    _webSocketIntegration?.NotifyError("Không có thông tin queue để gọi lui", counterId);
                    return;
                }

                var counter = GetCounterInfo(counterId);
                var service = GetServiceInfo(queueInfo.ServiceId);

                _webSocketIntegration?.NotifyCallPrevious(
                    counterId: counterId,
                    counterName: counter?.Name ?? string.Format("Quầy {0}", counterId),
                    currentNumber: queueInfo.Number,
                    serviceName: service?.Name ?? "Unknown Service",
                    customerName: queueInfo.CustomerName,
                    displayNumber: GetDisplayNumber(queueInfo) ?? queueInfo.Number.ToString().PadLeft(3, '0')
                );

                Console.WriteLine(string.Format("📤 Đã gửi CallPrevious: {0} tại {1}",
                    queueInfo.Number, counter?.Name ?? string.Format("Quầy {0}", counterId)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("WebSocket notification error (CallPrevious): " + ex.Message);
                _webSocketIntegration?.NotifyError("Lỗi gửi thông báo CallPrevious: " + ex.Message, counterId);
            }
        }

        private void NotifyWebSocketCallAgain(int counterId, QueueInfor queueInfo)
        {
            try
            {
                if (queueInfo == null)
                {
                    Debug.WriteLine("WebSocket notification error (CallAgain): queueInfo is null");
                    _webSocketIntegration?.NotifyError("Không có thông tin queue để gọi lại", counterId);
                    return;
                }

                var counter = GetCounterInfo(counterId);
                var service = GetServiceInfo(queueInfo.ServiceId);

                _webSocketIntegration?.NotifyCallAgain(
                    counterId: counterId,
                    counterName: counter?.Name ?? string.Format("Quầy {0}", counterId),
                    currentNumber: queueInfo.Number,
                    serviceName: service?.Name ?? "Unknown Service",
                    customerName: queueInfo.CustomerName,
                    displayNumber: GetDisplayNumber(queueInfo) ?? queueInfo.Number.ToString().PadLeft(3, '0')
                );

                Console.WriteLine(string.Format("📤 Đã gửi CallAgain: {0} tại {1}",
                    queueInfo.Number, counter?.Name ?? string.Format("Quầy {0}", counterId)));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("WebSocket notification error (CallAgain): " + ex.Message);
                _webSocketIntegration?.NotifyError("Lỗi gửi thông báo CallAgain: " + ex.Message, counterId);
            }
        }

        private void NotifyWebSocketCallPriority(int counterId, QueueInfor queueInfo, int number)
        {
            try
            {
                var counter = GetCounterInfo(counterId);
                var service = queueInfo != null ? GetServiceInfo(queueInfo.ServiceId) : null;

                _webSocketIntegration?.NotifyCallPriority(
                    counterId: counterId,
                    counterName: counter?.Name ?? $"Quầy {counterId}",
                    priorityNumber: queueInfo?.Number ?? number,
                    serviceName: service?.Name ?? "Unknown Service",
                    customerName: queueInfo?.CustomerName?? "Unknown",
                    displayNumber: queueInfo != null
                        ? (GetDisplayNumber(queueInfo) ?? number.ToString().PadLeft(3, '0'))
                        : number.ToString().PadLeft(3, '0')
                );

                Console.WriteLine($"📤 Đã gửi CallPriority: {queueInfo?.Number ?? number} tại {counter?.Name ?? $"Quầy {counterId}"}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("WebSocket notification error (CallPriority): " + ex.Message);
                _webSocketIntegration?.NotifyError("Lỗi gửi thông báo CallPriority: " + ex.Message, counterId);
            }
        }

        private Counter GetCounterInfo(int counterId)
        {
            try
            {
                return unitOfWork.CounterRepository.GetByPrimaryKey(counterId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error getting counter info: " + ex.Message);
                return null;
            }
        }

        private Service GetServiceInfo(int serviceId)
        {
            try
            {
                return unitOfWork.ServiceRepository.GetByPrimaryKey(serviceId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error getting service info: " + ex.Message);
                return null;
            }
        }

        #endregion

        #region Form Events

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                // Shutdown WebSocket server
                Console.WriteLine("🛑 Đang đóng WebSocket server...");
                _webSocketIntegration?.Shutdown();
                Console.WriteLine("✅ WebSocket server đã được đóng");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error during shutdown: " + ex.Message);
            }

            base.OnFormClosing(e);
        }

        #endregion

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Console.WriteLine("🛑 Đang đóng ứng dụng...");
                _webSocketIntegration?.Shutdown();
                _webSocketIntegration?.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Lỗi cleanup WebSocket: {ex.Message}");
            }
            //base.OnFormClosed(e);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}