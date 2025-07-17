namespace CallQueue.Core
{
    public class Counter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsCalling { get; set; }
        public string CallTime { get; set; }
        public int TotalServeCount { get; set; }
        public int ServeCountOfDay { get; set; }
        public int ServeCountOfWeek { get; set; }
        public int ServeCountOfMonth { get; set; }
        public int ServeCountOfYear { get; set; }
        public int IsMaster { get; set; }
        public int CurrentNumber { get; set; }
        public int CurrentServiceId { get; set; }
        public string Voice { get; set; }
        public string KeyboardId { get; set; }
        public int MasterKeyBoardId { get; set; }
        public string AddressCallCommand { get; set; }
        public string AddressPiorityNumber { get; set; }
        public string AddressDisplayNumber { get; set; }
        public string AddressRemainNumber { get; set; }
        public string DisplayLedId { get; set; }
        public int MasterDisplayLedId { get; set; }
        public string AddressDisplayLedMode { get; set; }
        public string AddressDisplayLedNumber { get; set; }
    }
}
