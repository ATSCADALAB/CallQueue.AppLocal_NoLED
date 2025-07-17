using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class DataPackage
    {
        public string Value { get; set; }

        public Status Status { get; set; }

        public DateTime TimeStamp { get; set; }      

        public static DataPackage GoodPackage(string value)
        {
            return new DataPackage()
            {
                Value = value,
                Status = Status.Good,
                TimeStamp = DateTime.Now
            };
        }

        public static DataPackage BadPackage(string value)
        {
            return new DataPackage()
            {
                Value = value,
                Status = Status.Bad,
                TimeStamp = DateTime.Now
            };
        }
    }
}
