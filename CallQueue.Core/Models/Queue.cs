using System;

namespace CallQueue.Core
{
    public class Queue
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ServiceId { get; set; }
        public int Number { get; set; }
    }
}
