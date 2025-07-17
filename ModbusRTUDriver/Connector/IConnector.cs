using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public interface IConnector
    {
        IManagement Management { get; }

        IDataIO DataIO { get; }

        IReader Reader { get; }

        IWriter Writer { get; }

        bool AllowAutoConnect { get; set; }

        bool IsConnected { get; }

        string Parametter { get; set; }

        event EventHandler Connected;

        event EventHandler Disconnected;

        int OpenConnector();

        int CloseConnector();

        void StartRead();

        void StopRead();      
    }
}
