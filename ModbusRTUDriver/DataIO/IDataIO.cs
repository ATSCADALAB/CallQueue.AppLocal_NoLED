using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public interface IDataIO
    {
        byte[] ReadBytes(Address address, ushort numberOfRegister);

        DataPackage ReadBool(Address address);

        DataPackage ReadByte(Address address);

        DataPackage ReadInt(Address address);

        DataPackage ReadWord(Address address);
        
        DataPackage ReadDInt(Address address);

        DataPackage ReadDWord(Address address);

        DataPackage ReadReal(Address address);

        int WriteBool(Address address, bool value);

        int WriteByte(Address address, byte value);

        int WriteInt(Address address, short value);

        int WriteWord(Address address, ushort value);

        int WriteDInt(Address address, int value);

        int WriteDWord(Address address, uint value);

        int WriteReal(Address address, float value);
    }
}
