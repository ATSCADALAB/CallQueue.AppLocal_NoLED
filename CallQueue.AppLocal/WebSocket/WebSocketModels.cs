// Bước 2: Tạo file WebSocketModels.cs trong thư mục WebSocket/

using System;
using System.Collections.Generic;

namespace CallQueue.AppLocal.WebSocket
{
    /// <summary>
    /// Base WebSocket message format
    /// </summary>
    public class WebSocketMessage
    {
        public string Type { get; set; }
        public object Data { get; set; }
        public DateTime Timestamp { get; set; }

        public WebSocketMessage()
        {
            Timestamp = DateTime.Now;
        }
    }

    /// <summary>
    /// Queue call data for different actions
    /// </summary>
    public class QueueCallData
    {
        public string Action { get; set; }
        public int CounterId { get; set; }
        public string CounterName { get; set; }
        public int CurrentNumber { get; set; }
        public int NextNumber { get; set; }
        public int PreviousNumber { get; set; }
        public string ServiceName { get; set; }
        public string DisplayNumber { get; set; }
        public DateTime CallTime { get; set; }
        public string Priority { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string CustomerName { get; set; }
        public QueueCallData()
        {
            CallTime = DateTime.Now;
            Success = true;
        }
    }

    /// <summary>
    /// Error data
    /// </summary>
    public class ErrorData
    {
        public int? CounterId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public DateTime Timestamp { get; set; }

        public ErrorData()
        {
            Timestamp = DateTime.Now;
        }

        public ErrorData(string message) : this()
        {
            ErrorMessage = message;
        }

        public ErrorData(string message, int counterId) : this(message)
        {
            CounterId = counterId;
        }
    }

    /// <summary>
    /// Client connection info
    /// </summary>
    public class ClientInfo
    {
        public string Id { get; set; }
        public DateTime ConnectedAt { get; set; }
        public string RemoteEndPoint { get; set; }

        public ClientInfo()
        {
            Id = Guid.NewGuid().ToString();
            ConnectedAt = DateTime.Now;
        }
    }

    /// <summary>
    /// WebSocket message types constants
    /// </summary>
    public static class MessageTypes
    {
        public const string QueueCallNext = "queue_call_next";
        public const string QueueCallPrevious = "queue_call_previous";
        public const string QueueCallAgain = "queue_call_again";
        public const string QueueCallPriority = "queue_call_priority";
        public const string SystemStatus = "system_status";
        public const string Error = "error";
        public const string Ping = "ping";
        public const string Pong = "pong";
        public const string GetStatus = "get_status";
        public const string CurrentStatus = "current_status";
        public const string TestVoice = "test_voice";
        public const string ClientConnected = "client_connected";
        public const string ClientDisconnected = "client_disconnected";
    }

    /// <summary>
    /// Queue action types constants
    /// </summary>
    public static class QueueActions
    {
        public const string CallNext = "call_next";
        public const string CallPrevious = "call_previous";
        public const string CallAgain = "call_again";
        public const string CallPriority = "call_priority";
        public const string Test = "test";
    }

    /// <summary>
    /// Priority levels
    /// </summary>
    public static class PriorityLevels
    {
        public const string Normal = "NORMAL";
        public const string High = "HIGH";
        public const string Critical = "CRITICAL";
        public const string VIP = "VIP";
    }
}