using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class ByteTag : TagBase
    {
        public ByteTag(string name, Address address, IConnector connector)
            : base(name, address, connector)
        {
            address.DataSize = 1;
            Address = address;
        }

        public override void Write(string value, bool writeUntilSuccess = false)
        {
            if (ClientAccess == ClientAccess.ReadOnly) return;

            var resultConvert = byte.TryParse(value, out byte valueConvert);
            if (!resultConvert) return;

            this.writer.Enqueue(new object[2]
            {
                (Func<int>)(() => this.dataIO.WriteByte(Address, valueConvert)),
                writeUntilSuccess
            });           
        }

        public override DataPackage Read(DataSource dataSource)
        {
            return dataSource == DataSource.Device ?
               this.dataIO.ReadByte(Address) :
               this.reader.ReadByte(Address);
        }
    }
}
