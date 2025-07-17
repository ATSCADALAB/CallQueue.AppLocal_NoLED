using System;

namespace CallQueue.Core
{
    public class QueueInfor
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Number { get; set; }
        public int ServiceId { get; set; }
        public int CounterId { get; set; }
        public string Mark { get; set; }
        public string CounterVoice { get; set; }
        public string NumberFormat { get; set; }
        public string CallVoiceContent { get; set; }

        // ===== THÊM PROPERTY MỚI =====
        public string CustomerName { get; set; } = "";
    }
}