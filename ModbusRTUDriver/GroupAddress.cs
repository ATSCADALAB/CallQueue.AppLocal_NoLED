using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public struct GroupAddress
    {      
        public Address StartAddress;
       
        public int IndexOfStartAddress;
       
        public ushort NumberOfRegister;
     
        public int CountTag;

        public GroupAddress(Address startAddress, int indexOfStartAddress, ushort numberOfRegister, int countTag)
        {
            StartAddress = startAddress;
            IndexOfStartAddress = indexOfStartAddress;
            NumberOfRegister = numberOfRegister;
            CountTag = countTag;
        }
    }
}
