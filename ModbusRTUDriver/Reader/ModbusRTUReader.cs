using System;

namespace ModbusRTUDriver
{
    public class ModbusRTUReader : IReader
    {     
        public byte[] DataCache { get; set; }     
       
        public DataPackage ReadBool(Address address)
        {
            if (DataCache == null) return DataPackage.BadPackage("0");

            var valueRead = new byte[2];
            Array.Copy(DataCache, address.IndexInCache, valueRead, 0, 2);

            bool valueConvert = (valueRead[0] & (1 << address.Bit)) > 0;
            return DataPackage.GoodPackage(valueConvert ? "1" : "0");
        }

        public DataPackage ReadByte(Address address)
        {
            if (DataCache == null) return DataPackage.BadPackage("0");

            var valueRead = new byte[2];
            Array.Copy(DataCache, address.IndexInCache, valueRead, 0, 2);

            byte valueConvert = valueRead[0];
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public DataPackage ReadInt(Address address)
        {
            if (DataCache == null) return DataPackage.BadPackage("0");

            var valueRead = new byte[2];
            Array.Copy(DataCache, address.IndexInCache, valueRead, 0, 2);

            Array.Reverse(valueRead);
            short valueConvert = BitConverter.ToInt16(valueRead, 0);
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public DataPackage ReadWord(Address address)
        {
            if (DataCache == null) return DataPackage.BadPackage("0");

            var valueRead = new byte[2];
            Array.Copy(DataCache, address.IndexInCache, valueRead, 0, 2);

            Array.Reverse(valueRead);
            ushort valueConvert = BitConverter.ToUInt16(valueRead, 0);
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public DataPackage ReadDInt(Address address)
        {
            if (DataCache == null) return DataPackage.BadPackage("0");

            var valueRead = new byte[4];
            Array.Copy(DataCache, address.IndexInCache, valueRead, 0, 4);

            Array.Reverse(valueRead);
            int valueConvert = BitConverter.ToInt32(valueRead, 0);
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public DataPackage ReadDWord(Address address)
        {
            if (DataCache == null) return DataPackage.BadPackage("0");

            var valueRead = new byte[4];
            Array.Copy(DataCache, address.IndexInCache, valueRead, 0, 4);

            Array.Reverse(valueRead);
            uint valueConvert = BitConverter.ToUInt32(valueRead, 0);
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public DataPackage ReadReal(Address address)
        {
            if (DataCache == null) return DataPackage.BadPackage("0");

            var valueRead = new byte[8];
            Array.Copy(DataCache, address.IndexInCache, valueRead, 0, 8);

            Array.Reverse(valueRead);
            float valueConvert = BitConverter.ToSingle(valueRead, 0);
            return DataPackage.GoodPackage(valueConvert.ToString());
        }
    }
}
