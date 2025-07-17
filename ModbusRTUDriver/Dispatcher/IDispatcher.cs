using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public interface IDispatcher
    {
        bool IsActive { get; }

        int UpdateRate { get; set; }

        void StartRead();

        void StopRead();        
    }
}
