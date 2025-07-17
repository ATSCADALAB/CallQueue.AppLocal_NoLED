using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class ModbusRTUManagement : IManagement
    {
        private readonly IConnector connector;

        private readonly List<ITag> tags;

        public ModbusRTUManagement(IConnector connector)
        {
            this.connector = connector;
            tags = new List<ITag>();
        }

        public ITag GetTagByIndex(int index)
        {
            if (index < 0 || index > tags.Count - 1) return null;
            return this.tags[index];
        }

        public ITag GetTagByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            return this.tags.Find(x => x.Name == name);
        }

        public List<ITag> GetAllTag()
        {
            return this.tags;
        }

        public bool IsExistTagName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;
            return this.tags.Any(x => x.Name == name);
        }

        public bool AddTag(string name, Address address)
        {
            if (IsExistTagName(name)) return false;

            var tag = TagBuilder.CreateNewTag()
                .WithName(name)
                .WithAddress(address)
                .WithConnector(this.connector)
                .Build();

            this.tags.Add(tag);
            return true;
        }

        public bool AddTag(string name, string addressStr, DataType dataType)
        {
            if (IsExistTagName(name) || string.IsNullOrWhiteSpace(addressStr)) return false;

            var address = GetAddress(addressStr, dataType);           

            var tag = TagBuilder.CreateNewTag()
                .WithName(name)
                .WithAddress(address)
                .WithConnector(this.connector)
                .Build();

            this.tags.Add(tag);
            return true;
        }

        public bool RemoveTag(ITag tag)
        {
            if (!this.tags.Contains(tag)) return false;
            this.tags.Remove(tag);
            return true;
        }

        public bool RemoveTagByName(string name)
        {
            var tag = GetTagByName(name);
            if (tag == null) return false;

            this.tags.Remove(tag);
            return true;
        }

        public bool RemoveTagByIndex(int index)
        {
            var tag = GetTagByIndex(index);
            if (tag == null) return false;

            this.tags.Remove(tag);
            return true;
        }

        private Address GetAddress(string addressStr, DataType dataType)
        {
            Address address = Address.Empty;
            if (string.IsNullOrEmpty(addressStr)) return address;

            var index = addressStr.IndexOf(':');
            if (index > 0)
            {
                if (byte.TryParse(addressStr.Substring(0, index), out byte deviceID))
                    address.DeviceID = deviceID;
                addressStr = addressStr.Substring(index + 1);
            }

            switch (addressStr[0])
            {
                case '0':
                    {
                        address.Area = ModbusProtocol.ReadCoil;
                        ushort.TryParse(addressStr, out ushort register);
                        address.Start = (ushort)(register / 16);
                        var bit = (byte)(register % 16);
                        address.Bit = bit == 0 ? (byte)16 : bit;

                        address.Bit--;
                        address.DataType = DataType.Bool;
                        address.ClientAccess = ClientAccess.ReadWrite;
                    }
                    break;
                case '1':
                    {
                        address.Area = ModbusProtocol.ReadDiscreteInputs;
                        ushort.TryParse(addressStr.Substring(1), out ushort register);
                        address.Start = (ushort)(register / 16);
                        var bit = (byte)(register % 16);
                        address.Bit = bit == 0 ? (byte)16 : bit;

                        address.Bit--;
                        address.DataType = DataType.Bool;
                        address.ClientAccess = ClientAccess.ReadOnly;
                    }
                    break;
                case '4':
                    {
                        int indexOfDot = addressStr.IndexOf('.');
                        address.Area = ModbusProtocol.ReadHoldingRegister;
                        if (indexOfDot > 0)
                        {
                            address.Start = ushort.Parse(addressStr.Substring(1, indexOfDot - 1));
                            address.Bit = byte.Parse(addressStr.Substring(indexOfDot + 1));
                        }
                        else address.Start = ushort.Parse(addressStr.Substring(1));

                        address.Start--;
                        address.DataType = dataType;
                        address.ClientAccess = ClientAccess.ReadWrite;
                    }
                    break;
                case '3':
                    {
                        int indexOfDot = addressStr.IndexOf('.');
                        address.Area = ModbusProtocol.ReadInputRegister;
                        if (indexOfDot > 0)
                        {
                            address.Start = ushort.Parse(addressStr.Substring(1, indexOfDot - 1));
                            address.Bit = byte.Parse(addressStr.Substring(indexOfDot + 1));
                        }
                        else address.Start = ushort.Parse(addressStr.Substring(1));

                        address.Start--;
                        address.DataType = dataType;
                        address.ClientAccess = ClientAccess.ReadOnly;
                    }
                    break;
            }

            return address;
        }
    }
}
