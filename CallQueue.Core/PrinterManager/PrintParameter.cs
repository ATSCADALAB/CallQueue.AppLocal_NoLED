using System;

namespace CallQueue.Core
{
    public class PrintParameter
    {
        public DateTime CurrentTime { get; set; }
        public int NextNumber { get; set; }
        public int ServiceId { get; set; }
        public string Mask { get; set; }
        public string ServiceName { get; set; }
    }
}
