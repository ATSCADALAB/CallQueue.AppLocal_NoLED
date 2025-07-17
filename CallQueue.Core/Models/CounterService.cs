namespace CallQueue.Core
{
    public class CounterService
    {
        public int CounterId { get; set; }
        public int ServiceId { get; set; }
        public int TotalCount { get; set; }
        public int CountOfDay { get; set; }
        public int CountOfWeek { get; set; }
        public int CountOfMonth { get; set; }
        public int CountOfYear { get; set; }
    }
}
