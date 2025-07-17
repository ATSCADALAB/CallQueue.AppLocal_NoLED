using System;
using System.Runtime.InteropServices;

namespace ModbusRTUDriver
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Address : IComparable<Address>
    {
        public byte DeviceID;

        public byte Area;

        public ushort Start;

        public byte Bit;

        public byte DataSize;  

        public DataType DataType;

        public ClientAccess ClientAccess;

        public int IndexInCache;

        public Address(byte deviceID, byte area, ushort start, byte bit, byte dataSize,  DataType dataType, ClientAccess clientAccess, int indexInCache = 0)
        {
            DeviceID = deviceID;
            Area = area;
            Start = start;
            Bit = bit;
            DataSize = dataSize;
            IndexInCache = indexInCache;
            DataType = dataType;
            ClientAccess = clientAccess;
        }

        public static Address Empty = new Address(0, 0, 0, 0, 0, DataType.None, ClientAccess.None);

        public int CompareTo(Address other)
        {
            return
                DeviceID > other.DeviceID ? 1 :
                DeviceID < other.DeviceID ? -1 :
                Area > other.Area ? 1 :
                Area < other.Area ? -1 :
                Start > other.Start ? 1 :
                Start < other.Start ? -1 :
                Bit > other.Bit ? 1 :
                Bit < other.Bit ? -1 :
                0;
        }
    }
}
