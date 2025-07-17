using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallQueue.Core
{
    public class CallHistory
    {
        public CallHistory()
        {
        }

        public int Id { get; set; }
        public DateTime PrintTime { get; set; }
        public DateTime CallTime { get; set; }
        public int ServiceId { get; set; }
        public int CounterId { get; set; }
        public string Information { get; set; }
        public int PrintedNumber { get; set; }
    }
}
