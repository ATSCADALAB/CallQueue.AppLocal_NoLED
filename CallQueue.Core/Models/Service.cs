namespace CallQueue.Core
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentNumber { get; set; }
        public int PrintedNumber { get; set; }
        public int PiorityLevel { get; set; }
        public int TotalUseCount { get; set; }
        public int UseCountOfDay { get; set; }
        public int UseCountOfWeek { get; set; }
        public int UseCountOfMonth { get; set; }
        public int UseCountOfYear { get; set; }
        public string Mark { get; set; }
        public int InputPin { get; set; }
    }
}
