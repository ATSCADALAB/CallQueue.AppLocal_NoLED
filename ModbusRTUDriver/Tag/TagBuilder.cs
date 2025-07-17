using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class TagBuilder
    {
        private string name;

        private Address address;

        private IConnector connector;        
      
        public static TagBuilder CreateNewTag()
        {
            return new TagBuilder();
        }

        public TagBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }

        public TagBuilder WithAddress(Address address)
        {
            this.address = address;
            return this;
        }

        public TagBuilder WithConnector(IConnector connector)
        {
            this.connector = connector;
            return this;
        }

        public ITag Build()
        {
            return TagFactory.CreateTag(this.name, this.address, this.connector);
        }
    }
}
