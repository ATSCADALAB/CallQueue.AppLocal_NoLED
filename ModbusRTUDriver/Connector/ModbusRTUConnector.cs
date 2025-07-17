using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class ModbusRTUConnector : IConnector
    {
        private bool isModbusRTU;

        private readonly IDispatcher dispatcher;

        private readonly ModbusRTUMaster driverPlugin;

        private readonly ModbusTCPCient modbusCient;

        private Channel channel;

        public IManagement Management { get; }

        public IDataIO DataIO { get; }

        public IReader Reader { get; }

        public IWriter Writer { get; }

        public bool AllowAutoConnect { get; set; }

        public bool IsConnected
        {
            get
            {
                if(this.isModbusRTU)
                    return this.driverPlugin.IsOpen;

                return this.modbusCient.Connected;
            }
        }

        public string Parametter { get; set; }

        public event EventHandler Connected;

        public event EventHandler Disconnected;

        public ModbusRTUConnector()
        {
            
        }

        public ModbusRTUConnector(string parametter)
        {           
            this.dispatcher = new ModbusRTUDispatcher(this);
            this.driverPlugin = new ModbusRTUMaster();
            this.modbusCient = new ModbusTCPCient();

            Parametter = parametter;
            this.isModbusRTU = parametter.Contains("COM");
            DataIO = new ModbusRTUDataIO(this.driverPlugin, this.modbusCient, this.isModbusRTU);
            Management = new ModbusRTUManagement(this);
            Reader = new ModbusRTUReader();
            Writer = new ModbusRTUWriter();
        }

        private void OnConnected()
        {
            EventHandler handler;
            lock (this) handler = Connected;
            handler?.Invoke(this, null);
        }

        private void OnDisconnected()
        {
            EventHandler handler;
            lock (this) handler = Disconnected;
            handler?.Invoke(this, null);
        }

        public int OpenConnector()
        {
            if (this.isModbusRTU)
            {
                if (this.driverPlugin.IsOpen) return -1;
                if (string.IsNullOrWhiteSpace(Parametter)) return -1;

                this.channel = new Channel(Parametter);
                var result = this.driverPlugin.Connect(this.channel);
                if (result == 0) OnConnected();

                return result;
            }

            var parts = Parametter.Split('.');
            var ip = $"{parts[0]}.{parts[1]}.{parts[2]}.{parts[3]}";
            var port = Convert.ToUInt16(parts[4]);
            this.modbusCient.Connect(ip, port);

            return 1;
        }

        public int CloseConnector()
        {
            if (this.isModbusRTU)
            {
                var result = this.driverPlugin.Disconnect();
                if (result == 0) OnDisconnected();

                return result;
            }

            this.modbusCient.Disconnect();
            return 1;
        }

        public void StartRead()
        {
            this.dispatcher.StartRead();
            return;
        }

        public void StopRead()
        {
            this.dispatcher.StopRead();
            return;
        }


    }
}
