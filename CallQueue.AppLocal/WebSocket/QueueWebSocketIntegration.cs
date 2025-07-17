// Bước 4: Tạo file QueueWebSocketIntegration.cs trong thư mục WebSocket/

using System;
using System.Diagnostics;

namespace CallQueue.AppLocal.WebSocket
{
    /// <summary>
    /// Integration helper cho WinForms sử dụng Fleck WebSocket
    /// Compatible với .NET Framework 4.5.2
    /// </summary>
    public class QueueWebSocketIntegration : IDisposable
    {
        private readonly QueueWebSocketServer _webSocketServer;
        private readonly object _lockObject = new object();
        private bool _isInitialized = false;
        private bool _isDisposed = false;

        // Events cho WinForms subscribe
        public event Action OnTestVoiceRequested;
        public event Action<ClientInfo> OnClientConnected;
        public event Action<ClientInfo> OnClientDisconnected;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port">WebSocket server port</param>
        public QueueWebSocketIntegration(int port = 8080)
        {
            _webSocketServer = new QueueWebSocketServer(port);
        }

        /// <summary>
        /// Get WebSocket server instance
        /// </summary>
        public QueueWebSocketServer WebSocketServer
        {
            get { return _webSocketServer; }
        }

        /// <summary>
        /// Initialize WebSocket integration
        /// </summary>
        /// <returns>True nếu khởi tạo thành công</returns>
        public bool Initialize()
        {
            try
            {
                lock (_lockObject)
                {
                    if (_isInitialized)
                    {
                        Console.WriteLine("WebSocket integration đã được khởi tạo");
                        return true;
                    }

                    // Setup event handlers
                    _webSocketServer.OnTestVoiceRequested += () =>
                    {
                        Console.WriteLine("🎤 Web client yêu cầu test voice");
                        Debug.WriteLine("Web client requested voice test");
                        OnTestVoiceRequested?.Invoke();
                    };

                    _webSocketServer.GetCurrentStatus += () =>
                    {
                        try
                        {
                            return new WebSocketMessage
                            {
                                Type = MessageTypes.CurrentStatus,
                                Data = GetCurrentSystemStatus()
                            };
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi lấy current status: " + ex.Message);
                            return new WebSocketMessage
                            {
                                Type = MessageTypes.Error,
                                Data = new ErrorData("Failed to get system status")
                            };
                        }
                    };

                    _webSocketServer.OnClientConnected += (clientInfo) =>
                    {
                        var message = string.Format("Client kết nối: {0}", clientInfo.Id);
                        Console.WriteLine(message);
                        Debug.WriteLine(message);
                        OnClientConnected?.Invoke(clientInfo);
                    };

                    _webSocketServer.OnClientDisconnected += (clientInfo) =>
                    {
                        var message = string.Format("Client ngắt kết nối: {0}", clientInfo.Id);
                        Console.WriteLine(message);
                        Debug.WriteLine(message);
                        OnClientDisconnected?.Invoke(clientInfo);
                    };

                    // Start WebSocket server
                    if (_webSocketServer.Start())
                    {
                        _isInitialized = true;
                        Console.WriteLine("✅ WebSocket integration (Fleck) khởi tạo thành công");
                        Debug.WriteLine("WebSocket integration initialized successfully");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("❌ Không thể khởi động WebSocket server");
                        Debug.WriteLine("Failed to start WebSocket server");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                var errorMessage = string.Format("❌ Lỗi khởi tạo WebSocket integration: {0}", ex.Message);
                Console.WriteLine(errorMessage);
                Debug.WriteLine("WebSocket integration initialization error: " + ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Lấy current system status (implement theo hệ thống của bạn)
        /// </summary>
        private object GetCurrentSystemStatus()
        {
            // TODO: Implement method này để lấy status thực từ hệ thống
            // Hiện tại return basic status
            return new
            {
                IsSystemActive = _isInitialized && _webSocketServer.IsRunning,
                TotalWaitingQueues = 0, // Implement từ database của bạn
                ConnectedClients = _webSocketServer.ConnectedClientCount,
                LastUpdate = DateTime.Now
            };
        }

        // ====================================================================================
        // Queue Notification Methods
        // ====================================================================================

        /// <summary>
        /// Thông báo "Gọi Tới" tới web clients
        /// </summary>
        public void NotifyCallNext(int counterId, string counterName, int currentNumber, 
            string serviceName, string customerName ,string displayNumber = null)
        {
            try
            {
                if (!_isInitialized || _isDisposed)
                {
                    Console.WriteLine("WebSocket integration chưa khởi tạo hoặc đã disposed");
                    return;
                }

                lock (_lockObject)
                {
                    _webSocketServer.BroadcastCallNext(counterId, counterName, currentNumber, 
                        serviceName, customerName, displayNumber);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi notify CallNext: " + ex.Message);
                Debug.WriteLine("NotifyCallNext error: " + ex.ToString());
            }
        }

        /// <summary>
        /// Thông báo "Gọi Lui" tới web clients
        /// </summary>
        public void NotifyCallPrevious(int counterId, string counterName, int currentNumber, 
            string serviceName, string customerName, string displayNumber = null)
        {
            try
            {
                if (!_isInitialized || _isDisposed)
                {
                    Console.WriteLine("WebSocket integration chưa khởi tạo hoặc đã disposed");
                    return;
                }

                lock (_lockObject)
                {
                    _webSocketServer.BroadcastCallPrevious(counterId, counterName, currentNumber, 
                        serviceName, customerName, displayNumber);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi notify CallPrevious: " + ex.Message);
                Debug.WriteLine("NotifyCallPrevious error: " + ex.ToString());
            }
        }

        /// <summary>
        /// Thông báo "Gọi Lại" tới web clients
        /// </summary>
        public void NotifyCallAgain(int counterId, string counterName, int currentNumber, 
            string serviceName, string customerName, string displayNumber = null)
        {
            try
            {
                if (!_isInitialized || _isDisposed)
                {
                    Console.WriteLine("WebSocket integration chưa khởi tạo hoặc đã disposed");
                    return;
                }

                lock (_lockObject)
                {
                    _webSocketServer.BroadcastCallAgain(counterId, counterName, currentNumber, 
                        serviceName, customerName, displayNumber);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi notify CallAgain: " + ex.Message);
                Debug.WriteLine("NotifyCallAgain error: " + ex.ToString());
            }
        }

        /// <summary>
        /// Thông báo "Gọi Ưu Tiên" tới web clients
        /// </summary>
        public void NotifyCallPriority(int counterId, string counterName, int priorityNumber, 
            string serviceName,string customerName, string displayNumber = null)
        {
            try
            {
                if (!_isInitialized || _isDisposed)
                {
                    Console.WriteLine("WebSocket integration chưa khởi tạo hoặc đã disposed");
                    return;
                }

                lock (_lockObject)
                {
                    _webSocketServer.BroadcastCallPriority(counterId, counterName, priorityNumber, 
                        serviceName, customerName, displayNumber);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi notify CallPriority: " + ex.Message);
                Debug.WriteLine("NotifyCallPriority error: " + ex.ToString());
            }
        }

        /// <summary>
        /// Thông báo lỗi tới web clients
        /// </summary>
        public void NotifyError(string errorMessage, int? counterId = null)
        {
            try
            {
                if (!_isInitialized || _isDisposed)
                {
                    Console.WriteLine("WebSocket integration chưa khởi tạo hoặc đã disposed");
                    return;
                }

                lock (_lockObject)
                {
                    _webSocketServer.BroadcastError(errorMessage, counterId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi notify error: " + ex.Message);
                Debug.WriteLine("NotifyError error: " + ex.ToString());
            }
        }

        // ====================================================================================
        // Status và Information Methods
        // ====================================================================================

        /// <summary>
        /// Kiểm tra WebSocket integration có đang chạy không
        /// </summary>
        public bool IsRunning
        {
            get
            {
                try
                {
                    return _isInitialized && !_isDisposed && _webSocketServer.IsRunning;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Số lượng web clients đang kết nối
        /// </summary>
        public int ConnectedClientCount
        {
            get
            {
                try
                {
                    return _webSocketServer?.ConnectedClientCount ?? 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Lấy thông tin server
        /// </summary>
        public string GetServerInfo()
        {
            try
            {
                if (_webSocketServer != null)
                {
                    return _webSocketServer.GetServerInfo();
                }
                return "WebSocket server chưa khởi tạo";
            }
            catch (Exception ex)
            {
                return "Lỗi lấy server info: " + ex.Message;
            }
        }
        /// <summary>
        /// Shutdown WebSocket integration
        /// </summary>
        public void Shutdown()
        {
            try
            {
                lock (_lockObject)
                {
                    if (_isInitialized && !_isDisposed)
                    {
                        Console.WriteLine("🛑 Đang shutdown WebSocket integration...");
                        Debug.WriteLine("Shutting down WebSocket integration");
                        
                        _webSocketServer?.Stop();
                        _isInitialized = false;
                        
                        Console.WriteLine("✅ WebSocket integration shutdown hoàn tất");
                        Debug.WriteLine("WebSocket integration shutdown completed");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi trong quá trình WebSocket shutdown: " + ex.Message);
                Debug.WriteLine("WebSocket shutdown error: " + ex.ToString());
            }
        }

        /// <summary>
        /// Dispose pattern implementation
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected dispose method
        /// </summary>
        /// <param name="disposing">True nếu disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    Shutdown();
                    _webSocketServer?.Dispose();
                }
                _isDisposed = true;
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~QueueWebSocketIntegration()
        {
            Dispose(false);
        }
    }
}