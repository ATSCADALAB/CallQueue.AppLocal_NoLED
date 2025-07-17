namespace CallQueue.Core
{
    public class ModbusMasterParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Port { get; set; }
        public int Baudrate { get; set; }
        public string Parity { get; set; }
        public string StopBits { get; set; }
        public int DataBits { get; set; }
    }
}
