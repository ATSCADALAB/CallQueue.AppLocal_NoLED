using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class ModbusProtocol
    {
        public const byte ReadCoil = 1;

        public const byte ReadDiscreteInputs = 2;

        public const byte ReadHoldingRegister = 3;

        public const byte ReadInputRegister = 4;

        public const byte WriteSingleCoil = 5;

        public const byte WriteSingleRegister = 6;

        public const byte WriteMultipleCoils = 15;

        public const byte WriteMultipleRegister = 16;

        public const byte ReadWriteMultipleRegister = 23;
    }
}
