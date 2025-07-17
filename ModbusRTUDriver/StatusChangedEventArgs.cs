using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class StatusChangedEventArgs : EventArgs
    {
        public DateTime TimeStamp { get; set; }

        public Status OldStatus { get; set; }

        public Status NewStatus { get; set; }

        public StatusChangedEventArgs(DateTime timeStamp, Status oldStatus, Status newStatus)
        {
            TimeStamp = timeStamp;
            OldStatus = oldStatus;
            NewStatus = newStatus;
        }
    }
}
