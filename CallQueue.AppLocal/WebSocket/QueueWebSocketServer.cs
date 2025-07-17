// Bước 3: Tạo file QueueWebSocketServer.cs trong thư mục WebSocket/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Fleck;
using Newtonsoft.Json;

namespace CallQueue.AppLocal.WebSocket
{
    /// <summary>
    /// WebSocket Server using Fleck library
    /// Compatible with .NET Framework 4.5.2
    /// </summary>
    public class QueueWebSocketServer
    {
        private WebSocketServer _server;
        private readonly int _port;
        private readonly string _location;
        private bool _isRunning = false;
        private readonly object _lockObject = new object();

        // Dictionary để track tất cả connections
        private readonly Dictionary<Guid, IWebSocketConnection> _connections;
        private readonly Dictionary<Guid, ClientInfo> _clientInfos;

        // Events cho WinForms subscribe
        public event Action OnTestVoiceRequested;
        public event Func<WebSocketMessage> GetCurrentStatus;
        public event Action<ClientInfo> OnClientConnected;
        public event Action<ClientInfo> OnClientDisconnected;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port">Port cho WebSocket server</param>
        public QueueWebSocketServer(int port = 8080)
        {
            _port = port;
            _location = string.Format("ws://192.168.1.100:{0}", port);
            _connections = new Dictionary<Guid, IWebSocketConnection>();
            _clientInfos = new Dictionary<Guid, ClientInfo>();
        }

        /// <summary>
        /// Start WebSocket server
        /// </summary>
        /// <returns>True nếu start thành công</returns>
        public bool Start()
        {
            try
            {
                lock (_lockObject)
                {
                    if (_isRunning)
                    {
                        Console.WriteLine("WebSocket server đã đang chạy");
                        return true;
                    }

                    // Tắt log của Fleck (optional)
                    FleckLog.Level = LogLevel.Error;

                    _server = new WebSocketServer(_location);

                    _server.Start(socket =>
                    {
                        socket.OnOpen = () => OnSocketOpen(socket);
                        socket.OnClose = () => OnSocketClose(socket);
                        socket.OnMessage = msg => OnSocketMessage(socket, msg);
                        socket.OnError = exception => OnSocketError(socket, exception);
                    });

                    _isRunning = true;

                    var message = string.Format("✅ WebSocket server (Fleck) started on {0}", _location);
                    Console.WriteLine(message);
                    Debug.WriteLine(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                var errorMessage = string.Format("❌ Failed to start WebSocket server: {0}", ex.Message);
                Console.WriteLine(errorMessage);
                Debug.WriteLine("WebSocket server start error: " + ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Stop WebSocket server
        /// </summary>
        public void Stop()
        {
            try
            {
                lock (_lockObject)
                {
                    if (_isRunning && _server != null)
                    {
                        // Đóng tất cả connections
                        DisconnectAllClients();

                        _server.Dispose();
                        _server = null;
                        _isRunning = false;

                        Console.WriteLine("🛑 WebSocket server stopped");
                        Debug.WriteLine("WebSocket server stopped");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error stopping WebSocket server: " + ex.Message);
                Debug.WriteLine("WebSocket server stop error: " + ex.ToString());
            }
        }

        // ====================================================================================
        // Socket Event Handlers
        // ====================================================================================

        private void OnSocketOpen(IWebSocketConnection socket)
        {
            try
            {
                var clientInfo = new ClientInfo
                {
                    RemoteEndPoint = socket.ConnectionInfo.ClientIpAddress + ":" + socket.ConnectionInfo.ClientPort
                };

                lock (_lockObject)
                {
                    _connections[socket.ConnectionInfo.Id] = socket;
                    _clientInfos[socket.ConnectionInfo.Id] = clientInfo;
                }

                var message = string.Format("Client connected: {0} from {1}. Total: {2}",
                    clientInfo.Id, clientInfo.RemoteEndPoint, _connections.Count);
                Console.WriteLine(message);
                Debug.WriteLine(message);

                // Send welcome message
                SendWelcomeMessage(socket, clientInfo);

                // Notify WinForms
                OnClientConnected?.Invoke(clientInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in OnSocketOpen: " + ex.Message);
                Debug.WriteLine("OnSocketOpen error: " + ex.ToString());
            }
        }

        private void OnSocketClose(IWebSocketConnection socket)
        {
            try
            {
                ClientInfo clientInfo = null;

                lock (_lockObject)
                {
                    if (_clientInfos.ContainsKey(socket.ConnectionInfo.Id))
                    {
                        clientInfo = _clientInfos[socket.ConnectionInfo.Id];
                        _clientInfos.Remove(socket.ConnectionInfo.Id);
                    }

                    _connections.Remove(socket.ConnectionInfo.Id);
                }

                var message = string.Format("Client disconnected: {0}. Total: {1}",
                    clientInfo?.Id ?? "Unknown", _connections.Count);
                Console.WriteLine(message);
                Debug.WriteLine(message);

                // Notify WinForms
                if (clientInfo != null)
                {
                    OnClientDisconnected?.Invoke(clientInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in OnSocketClose: " + ex.Message);
                Debug.WriteLine("OnSocketClose error: " + ex.ToString());
            }
        }

        private void OnSocketMessage(IWebSocketConnection socket, string msg)
        {
            try
            {
                var wsMessage = JsonConvert.DeserializeObject<WebSocketMessage>(msg);

                var logMessage = string.Format("Received from {0}: {1}",
                    socket.ConnectionInfo.ClientIpAddress, wsMessage.Type);
                Console.WriteLine(logMessage);
                Debug.WriteLine(logMessage);

                ProcessMessage(socket, wsMessage);
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine("Invalid JSON from client: " + jsonEx.Message);
                SendErrorToClient(socket, "Invalid message format");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message processing error: " + ex.Message);
                Debug.WriteLine("OnSocketMessage error: " + ex.ToString());
                SendErrorToClient(socket, "Message processing failed");
            }
        }

        private void OnSocketError(IWebSocketConnection socket, Exception exception)
        {
            var errorMsg = string.Format("WebSocket error for {0}: {1}",
                socket.ConnectionInfo.ClientIpAddress, exception.Message);
            Console.WriteLine(errorMsg);
            Debug.WriteLine("Socket error: " + exception.ToString());
        }

        // ====================================================================================
        // Message Processing
        // ====================================================================================

        private void ProcessMessage(IWebSocketConnection socket, WebSocketMessage message)
        {
            if (message?.Type == null) return;

            switch (message.Type.ToLower())
            {
                case MessageTypes.Ping:
                    HandlePing(socket);
                    break;

                case MessageTypes.GetStatus:
                    HandleGetStatus(socket);
                    break;

                case MessageTypes.TestVoice:
                    HandleTestVoice();
                    break;

                default:
                    Console.WriteLine("Unknown message type: " + message.Type);
                    break;
            }
        }

        private void HandlePing(IWebSocketConnection socket)
        {
            var pongMessage = new WebSocketMessage
            {
                Type = MessageTypes.Pong,
                Data = new { timestamp = DateTime.Now }
            };
            SendToClient(socket, pongMessage);
        }

        private void HandleGetStatus(IWebSocketConnection socket)
        {
            try
            {
                if (GetCurrentStatus != null)
                {
                    var status = GetCurrentStatus();
                    SendToClient(socket, status);
                }
                else
                {
                    SendErrorToClient(socket, "Status not available");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting status: " + ex.Message);
                SendErrorToClient(socket, "Failed to get status");
            }
        }

        private void HandleTestVoice()
        {
            try
            {
                Console.WriteLine("Client requested voice test");
                OnTestVoiceRequested?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error handling test voice: " + ex.Message);
            }
        }

        // ====================================================================================
        // Messaging Methods
        // ====================================================================================

        private void SendWelcomeMessage(IWebSocketConnection socket, ClientInfo clientInfo)
        {
            var welcomeMessage = new WebSocketMessage
            {
                Type = MessageTypes.ClientConnected,
                Data = new
                {
                    message = "Connected to Queue Management System",
                    clientId = clientInfo.Id,
                    serverTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                }
            };
            SendToClient(socket, welcomeMessage);
        }

        private void SendErrorToClient(IWebSocketConnection socket, string errorMessage)
        {
            var errorData = new ErrorData(errorMessage);
            var message = new WebSocketMessage
            {
                Type = MessageTypes.Error,
                Data = errorData
            };
            SendToClient(socket, message);
        }

        private void SendToClient(IWebSocketConnection socket, WebSocketMessage message)
        {
            try
            {
                if (socket.IsAvailable)
                {
                    var json = JsonConvert.SerializeObject(message, Formatting.None);
                    socket.Send(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending to client: " + ex.Message);
                Debug.WriteLine("SendToClient error: " + ex.ToString());
            }
        }

        /// <summary>
        /// Broadcast message to all connected clients
        /// </summary>
        public void BroadcastToAll(WebSocketMessage message)
        {
            if (message == null) return;

            var json = JsonConvert.SerializeObject(message, Formatting.None);
            var successCount = 0;
            var clientsToRemove = new List<Guid>();

            lock (_lockObject)
            {
                foreach (var kvp in _connections.ToArray())
                {
                    try
                    {
                        if (kvp.Value.IsAvailable)
                        {
                            kvp.Value.Send(json);
                            successCount++;
                        }
                        else
                        {
                            clientsToRemove.Add(kvp.Key);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Broadcast error to client " + kvp.Key + ": " + ex.Message);
                        clientsToRemove.Add(kvp.Key);
                    }
                }

                // Remove disconnected clients
                foreach (var clientId in clientsToRemove)
                {
                    _connections.Remove(clientId);
                    _clientInfos.Remove(clientId);
                }
            }

            var logMessage = string.Format("Broadcasted {0} to {1} clients. Removed {2} disconnected.",
                message.Type, successCount, clientsToRemove.Count);
            Console.WriteLine(logMessage);
            Debug.WriteLine(logMessage);
        }

        // ====================================================================================
        // Broadcast Methods cho Queue Actions
        // ====================================================================================

        public void BroadcastCallNext(int counterId, string counterName, int currentNumber,
            string serviceName, string customerName, string displayNumber = null)
        {
            try
            {
                var data = new QueueCallData
                {
                    Action = QueueActions.CallNext,
                    CounterId = counterId,
                    CounterName = counterName ?? string.Format("Quầy {0}", counterId),
                    CurrentNumber = currentNumber,
                    NextNumber = currentNumber + 1,
                    ServiceName = serviceName ?? "Unknown Service",
                    DisplayNumber = displayNumber ?? currentNumber.ToString().PadLeft(3, '0'),
                    Message = string.Format("Đã gọi số {0} tại {1}", currentNumber, counterName),
                    CustomerName= customerName
                };

                var message = new WebSocketMessage
                {
                    Type = MessageTypes.QueueCallNext,
                    Data = data
                };

                BroadcastToAll(message);
                Console.WriteLine(string.Format("Broadcasted CallNext: {0} at {1}", currentNumber, counterName));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error broadcasting CallNext: " + ex.Message);
            }
        }

        public void BroadcastCallPrevious(int counterId, string counterName, int currentNumber,
            string serviceName, string customerName, string displayNumber = null)
        {
            try
            {
                var data = new QueueCallData
                {
                    Action = QueueActions.CallPrevious,
                    CounterId = counterId,
                    CounterName = counterName ?? string.Format("Quầy {0}", counterId),
                    CurrentNumber = currentNumber,
                    PreviousNumber = Math.Max(1, currentNumber - 1),
                    ServiceName = serviceName ?? "Unknown Service",
                    DisplayNumber = displayNumber ?? currentNumber.ToString().PadLeft(3, '0'),
                    Message = string.Format("Đã gọi lui số {0} tại {1}", currentNumber, counterName),
                    CustomerName = customerName
                };

                var message = new WebSocketMessage
                {
                    Type = MessageTypes.QueueCallPrevious,
                    Data = data
                };

                BroadcastToAll(message);
                Console.WriteLine(string.Format("Broadcasted CallPrevious: {0} at {1}", currentNumber, counterName));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error broadcasting CallPrevious: " + ex.Message);
            }
        }

        public void BroadcastCallAgain(int counterId, string counterName, int currentNumber,
            string serviceName, string customerName, string displayNumber = null)
        {
            try
            {
                var data = new QueueCallData
                {
                    Action = QueueActions.CallAgain,
                    CounterId = counterId,
                    CounterName = counterName ?? string.Format("Quầy {0}", counterId),
                    CurrentNumber = currentNumber,
                    ServiceName = serviceName ?? "Unknown Service",
                    DisplayNumber = displayNumber ?? currentNumber.ToString().PadLeft(3, '0'),
                    Message = string.Format("Đã gọi lại số {0} tại {1}", currentNumber, counterName),
                    CustomerName = customerName
                };

                var message = new WebSocketMessage
                {
                    Type = MessageTypes.QueueCallAgain,
                    Data = data
                };

                BroadcastToAll(message);
                Console.WriteLine(string.Format("Broadcasted CallAgain: {0} at {1}", currentNumber, counterName));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error broadcasting CallAgain: " + ex.Message);
            }
        }

        public void BroadcastCallPriority(int counterId, string counterName, int priorityNumber,
            string serviceName, string customerName, string displayNumber = null)
        {
            try
            {
                var data = new QueueCallData
                {
                    Action = QueueActions.CallPriority,
                    CounterId = counterId,
                    CounterName = counterName ?? string.Format("Quầy {0}", counterId),
                    CurrentNumber = priorityNumber,
                    ServiceName = serviceName ?? "Unknown Service",
                    DisplayNumber = displayNumber ?? priorityNumber.ToString().PadLeft(3, '0'),
                    Priority = PriorityLevels.High,
                    Message = string.Format("Đã gọi ưu tiên số {0} tại {1}", priorityNumber, counterName),
                    CustomerName= customerName
                };

                var message = new WebSocketMessage
                {
                    Type = MessageTypes.QueueCallPriority,
                    Data = data
                };

                BroadcastToAll(message);
                Console.WriteLine(string.Format("Broadcasted CallPriority: {0} at {1}", priorityNumber, counterName));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error broadcasting CallPriority: " + ex.Message);
            }
        }

        public void BroadcastError(string errorMessage, int? counterId = null)
        {
            try
            {
                var data = new ErrorData(errorMessage);
                if (counterId.HasValue)
                {
                    data.CounterId = counterId.Value;
                }

                var message = new WebSocketMessage
                {
                    Type = MessageTypes.Error,
                    Data = data
                };

                BroadcastToAll(message);
                Console.WriteLine("Broadcasted error: " + errorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error broadcasting error: " + ex.Message);
            }
        }

        // ====================================================================================
        // Properties và Utilities
        // ====================================================================================

        public bool IsRunning
        {
            get
            {
                lock (_lockObject)
                {
                    return _isRunning;
                }
            }
        }

        public int ConnectedClientCount
        {
            get
            {
                lock (_lockObject)
                {
                    return _connections.Count;
                }
            }
        }

        public string GetServerInfo()
        {
            return string.Format("Fleck WebSocket Server - Location: {0}, Running: {1}, Clients: {2}",
                _location, _isRunning, ConnectedClientCount);
        }

        private void DisconnectAllClients()
        {
            lock (_lockObject)
            {
                foreach (var connection in _connections.Values.ToArray())
                {
                    try
                    {
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error disconnecting client: " + ex.Message);
                    }
                }
                _connections.Clear();
                _clientInfos.Clear();
            }
        }

        public void Dispose()
        {
            Stop();
        }
    }
}