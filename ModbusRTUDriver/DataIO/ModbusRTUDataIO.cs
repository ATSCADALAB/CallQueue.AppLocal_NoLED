using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ModbusRTUDriver
{
    public class ModbusRTUDataIO : IDataIO
    {
        public readonly ModbusTCPCient modbusClient;

        private readonly ModbusRTUMaster driverPlugin;

        private readonly bool isModbusRTU;

        public ModbusRTUDataIO(ModbusRTUMaster driverPlugin, ModbusTCPCient modbusClient, bool isModbusRTU)
        {           
            this.driverPlugin = driverPlugin;
            this.modbusClient = modbusClient;
            this.isModbusRTU = isModbusRTU;
        }

        public byte[] ReadBytes(Address address, ushort numberOfRegister)
        {
            if (this.isModbusRTU)
            {
                byte[] valueRead;
                byte numbeOfRead = 0;

                while (numbeOfRead < 3)
                {
                    valueRead = this.driverPlugin.ReadBytes(address, numberOfRegister);
                    if (valueRead != null) return valueRead;

                    Thread.Sleep(200);
                    numbeOfRead++;
                }

                return null;
            }


            var values = new byte[2 * numberOfRegister];
            this.modbusClient.ReadHoldingRegister(address.DeviceID, address.DeviceID, address.Start, numberOfRegister, ref values);

            return values;
        }

        public DataPackage ReadBool(Address address)
        {
            byte[] valueRead = this.ReadBytes(address, 1);
            if (valueRead == null) return DataPackage.BadPackage("0");

            bool valueConvert = (valueRead[0] & (1 << address.Bit)) > 0;
            return DataPackage.GoodPackage(valueConvert ? "1" : "0");
        }

        public DataPackage ReadByte(Address address)
        {
            byte[] valueRead = this.ReadBytes(address, 1);
            if (valueRead == null) return DataPackage.BadPackage("0");

            byte valueConvert = valueRead[0];
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public DataPackage ReadInt(Address address)
        {
            byte[] valueRead = this.ReadBytes(address, 1);
            if (valueRead == null) return DataPackage.BadPackage("0");

            Array.Reverse(valueRead);
            short valueConvert = BitConverter.ToInt16(valueRead, 0);
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public DataPackage ReadWord(Address address)
        {
            byte[] valueRead = this.ReadBytes(address, 1);
            if (valueRead == null) return DataPackage.BadPackage("0");

            Array.Reverse(valueRead);
            ushort valueConvert = BitConverter.ToUInt16(valueRead, 0);
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public DataPackage ReadDInt(Address address)
        {
            byte[] valueRead = this.ReadBytes(address, 2);
            if (valueRead == null) return DataPackage.BadPackage("0");

            Array.Reverse(valueRead);
            int valueConvert = BitConverter.ToInt32(valueRead, 0);
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public DataPackage ReadDWord(Address address)
        {
            byte[] valueRead = this.ReadBytes(address, 2);
            if (valueRead == null) return DataPackage.BadPackage("0");

            Array.Reverse(valueRead);
            uint valueConvert = BitConverter.ToUInt32(valueRead, 0);
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public DataPackage ReadReal(Address address)
        {
            byte[] valueRead = this.ReadBytes(address, 4);
            if (valueRead == null) return DataPackage.BadPackage("0");

            Array.Reverse(valueRead);
            float valueConvert = BitConverter.ToSingle(valueRead, 0);
            return DataPackage.GoodPackage(valueConvert.ToString());
        }

        public int WriteBool(Address address, bool value)
        {
            int qualityWrite = -1;
            byte numberOfWrite = 0;

            while (numberOfWrite < 3)
            {
                qualityWrite = this.driverPlugin.WriteSingleCoil(address.DeviceID, (ushort)(address.Start * 8 + address.Bit), value);
                if (qualityWrite == 0) return 0;

                Thread.Sleep(200);
                numberOfWrite++;
            }

            return qualityWrite;            
        }

        public int WriteByte(Address address, byte value)
        {
            byte[] valueWrite = new byte[2] { 0, value };
            return this.WriteHoldingRegisters(address.DeviceID, address.Start, 1, valueWrite);
        }

        public int WriteInt(Address address, short value)
        {
            byte[] valueWrite = BitConverter.GetBytes(value);
            Array.Reverse(valueWrite);

            return this.WriteHoldingRegisters(address.DeviceID, address.Start, 1, valueWrite);          
        }

        public int WriteWord(Address address, ushort value)
        {
            byte[] valueWrite = BitConverter.GetBytes(value);
            Array.Reverse(valueWrite);

            if (this.isModbusRTU)
            {                
                return this.WriteHoldingRegisters(address.DeviceID, address.Start, 1, valueWrite);
            }

            var result = new byte[1];
            this.modbusClient.WriteMultipleRegister(address.DeviceID, address.DeviceID, address.Start, valueWrite, ref result);
            return 0;
        }

        public int WriteDInt(Address address, int value)
        {
            byte[] valueWrite = BitConverter.GetBytes(value);
            Array.Reverse(valueWrite);

            return this.WriteHoldingRegisters(address.DeviceID, address.Start, 2, valueWrite);
        }

        public int WriteDWord(Address address, uint value)
        {
            byte[] valueWrite = BitConverter.GetBytes(value);
            Array.Reverse(valueWrite);

            return this.WriteHoldingRegisters(address.DeviceID, address.Start, 2, valueWrite);
        }

        public int WriteReal(Address address, float value)
        {
            byte[] valueWrite = BitConverter.GetBytes(value);
            Array.Reverse(valueWrite);

            return this.WriteHoldingRegisters(address.DeviceID, address.Start, 4, valueWrite);
        }

        private int WriteHoldingRegisters(byte deviceID, ushort startRegister, ushort numberOfRegisters, byte[] values)
        {
            int qualityWrite = -1;
            byte numberOfWrite = 0;

            while (numberOfWrite < 3)
            {
                qualityWrite = this.driverPlugin.WriteHoldingRegisters(deviceID, startRegister, numberOfRegisters, values);
                if (qualityWrite == 0) return 0;

                Thread.Sleep(200);
                numberOfWrite++;
            }

            return qualityWrite;
        }
    }
}
