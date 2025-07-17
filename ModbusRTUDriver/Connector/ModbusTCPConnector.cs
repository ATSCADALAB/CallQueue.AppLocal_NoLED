using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class ModbusTCPConnector : IConnector
    {
        private readonly IDispatcher dispatcher;

        private ModbusTCPCient modbusClient;

        public IManagement Management { get; }

        public IDataIO DataIO { get; }

        public IReader Reader { get; }

        public IWriter Writer { get; }

        public bool AllowAutoConnect { get; set; }

        public bool IsConnected => this.modbusClient.Connected;

        public string Parametter { get; set; }

        public event EventHandler Connected;

        public event EventHandler Disconnected;

        public int OpenConnector()
        {
            throw new NotImplementedException();
        }

        public int CloseConnector()
        {
            throw new NotImplementedException();
        }       

        public void StartRead()
        {
            throw new NotImplementedException();
        }

        public void StopRead()
        {
            throw new NotImplementedException();
        }
    }
}
