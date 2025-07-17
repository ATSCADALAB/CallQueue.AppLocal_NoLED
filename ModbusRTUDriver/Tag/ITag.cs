using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public interface ITag : IComparable<ITag>
    {
        string Name { get; }

        Address Address { get; set; }

        IConnector Connector { get; }

        ClientAccess ClientAccess { get; }

        string Value { get; }

        Status Status { get; }

        DateTime TimeStamp { get; }

        event EventHandler<ValueChangedEventArgs> ValueChanged;

        event EventHandler<StatusChangedEventArgs> StatusChanged;

        void Update(DataPackage dataPackage);

        void Write(string value, bool writeUntilSuccess = false);

        DataPackage Read(DataSource dataSource);
    }
}
