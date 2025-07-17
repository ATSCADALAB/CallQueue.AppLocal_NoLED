using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class TagFactory
    {
        public static ITag CreateTag(string name, Address address, IConnector connector)
        {
            switch (address.DataType)
            {
                case DataType.Bool:
                    return new BoolTag(name, address, connector);
                case DataType.Byte:
                    return new ByteTag(name, address, connector);
                case DataType.Int:
                    return new IntTag(name, address, connector);
                case DataType.Word:
                    return new WordTag(name, address, connector);
                case DataType.DInt:
                    return new DIntTag(name, address, connector);
                case DataType.DWord:
                    return new DWordTag(name, address, connector);
                case DataType.Real:
                    return new RealTag(name, address, connector);
                default:
                    return null;
            }
        }
    }
}
