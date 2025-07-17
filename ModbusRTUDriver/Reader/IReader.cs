using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public interface IReader
    {
        byte[] DataCache { get; set; }       

        DataPackage ReadBool(Address address);

        DataPackage ReadByte(Address address);

        DataPackage ReadInt(Address address);

        DataPackage ReadWord(Address address);

        DataPackage ReadDInt(Address address);

        DataPackage ReadDWord(Address address);

        DataPackage ReadReal(Address address);
    }
}
