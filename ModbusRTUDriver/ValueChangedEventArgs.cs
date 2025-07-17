using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class ValueChangedEventArgs : EventArgs
    {
        public DateTime TimeStamp { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public ValueChangedEventArgs(DateTime timeStamp, string oldValue, string newValue)
        {
            TimeStamp = timeStamp;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
