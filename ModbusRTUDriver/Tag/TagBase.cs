using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public abstract class TagBase : ITag
    {
        protected readonly IDataIO dataIO;

        protected readonly IReader reader;

        protected readonly IWriter writer;

        public string Name { get; }

        public Address Address { get; set; }

        public IConnector Connector { get; }

        public ClientAccess ClientAccess { get; }

        public string Value { get; private set; }

        public Status Status { get; private set; }

        public DateTime TimeStamp { get; private set; }

        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        public event EventHandler<StatusChangedEventArgs> StatusChanged;       

        public TagBase(string name, Address address, IConnector connector)
        {
            Name = name;            
            Connector = connector;
            ClientAccess = address.ClientAccess;

            this.dataIO = connector.DataIO;
            this.reader = connector.Reader;
            this.writer = connector.Writer;
        }

        protected void OnValueChanged(ValueChangedEventArgs e)
        {
            EventHandler<ValueChangedEventArgs> handler;
            lock (this) handler = ValueChanged;

            handler?.Invoke(this, e);
        }

        protected void OnStatusChanged(StatusChangedEventArgs e)
        {
            EventHandler<StatusChangedEventArgs> handler;
            lock (this) handler = StatusChanged;

            handler?.Invoke(this, e);
        }

        public virtual void Update(DataPackage dataPackage)
        {
            if (dataPackage.TimeStamp <= TimeStamp) return;

            var oldValue = Value;
            var oldStatus = Status;

            Value = dataPackage.Value;
            Status = dataPackage.Status;
            TimeStamp = dataPackage.TimeStamp;

            if (oldValue != dataPackage.Value) OnValueChanged(new ValueChangedEventArgs(TimeStamp, oldValue, Value));
            if (oldStatus != dataPackage.Status) OnStatusChanged(new StatusChangedEventArgs(TimeStamp, oldStatus, Status));
        }

        public abstract void Write(string value, bool writeUntilSuccess = false);

        public abstract DataPackage Read(DataSource dataSource);


        public int CompareTo(ITag other)
        {
            return Address.CompareTo(other.Address);
        }
    }
}
