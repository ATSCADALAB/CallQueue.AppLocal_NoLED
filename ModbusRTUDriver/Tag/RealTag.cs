using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class RealTag : TagBase
    {
        public RealTag(string name, Address address, IConnector connector)
            : base(name, address, connector)
        {
            address.DataSize = 4;
            Address = address;
        }

        public override void Write(string value, bool writeUntilSuccess = false)
        {
            if (ClientAccess == ClientAccess.ReadOnly) return;

            var resultConvert = float.TryParse(value, out float valueConvert);
            if (!resultConvert) return;

            this.writer.Enqueue(new object[2]
            {
                (Func<int>)(() => this.dataIO.WriteReal(Address, valueConvert)),
                writeUntilSuccess
            });
        }

        public override DataPackage Read(DataSource dataSource)
        {
            return dataSource == DataSource.Device ?
               this.dataIO.ReadReal(Address) :
               this.reader.ReadReal(Address);
        }
    }
}
