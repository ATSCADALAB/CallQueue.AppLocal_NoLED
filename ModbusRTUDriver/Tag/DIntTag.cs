using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class DIntTag : TagBase
    {
        public DIntTag(string name, Address address, IConnector connector)
            : base(name, address, connector)
        {
            address.DataSize = 2;
            Address = address;
        }

        public override void Write(string value, bool writeUntilSuccess = false)
        {
            if (ClientAccess == ClientAccess.ReadOnly) return;

            var resultConvert = int.TryParse(value, out int valueConvert);
            if (!resultConvert) return;

            this.writer.Enqueue(new object[2]
            {
                (Func<int>)(() => this.dataIO.WriteDInt(Address, valueConvert)),
                writeUntilSuccess
            });            
        }

        public override DataPackage Read(DataSource dataSource)
        {
            return dataSource == DataSource.Device ?
               this.dataIO.ReadDInt(Address) :
               this.reader.ReadDInt(Address);
        }
    }
}
