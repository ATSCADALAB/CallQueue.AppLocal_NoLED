using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class WordTag : TagBase
    {
        public WordTag(string name, Address address, IConnector connector)
            : base(name, address, connector)
        {
            address.DataSize = 1;
            Address = address;
        }

        public override void Update(DataPackage dataPackage)
        {
            base.Update(dataPackage);
        }

        public override void Write(string value, bool writeUntilSuccess = false)
        {
            if (ClientAccess == ClientAccess.ReadOnly) return;

            var resultConvert = ushort.TryParse(value, out ushort valueConvert);
            if (!resultConvert) return;

            this.writer.Enqueue(new object[2]
            {
                (Func<int>)(() => 
                {
                    return this.dataIO.WriteWord(Address, valueConvert);
                }),
                writeUntilSuccess
            });          
        }

        public override DataPackage Read(DataSource dataSource)
        {
            return dataSource == DataSource.Device ?
               this.dataIO.ReadWord(Address) :
               this.reader.ReadWord(Address);
        }
    }
}
