using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ModbusRTUDriver
{
    public class ModbusRTUWriter : IWriter
    {
        private readonly ConcurrentQueue<object[]> dataQueue;

        public int Count => this.dataQueue.Count;

        public ModbusRTUWriter()
        {
            this.dataQueue = new ConcurrentQueue<object[]>();
        }

        public void Enqueue(object[] item)
        {
            this.dataQueue.Enqueue(item);
        }

        public object[] Dequeue()
        {           
            if (this.dataQueue.TryDequeue(out object[] item)) return item;            
            return null;
        }
    }
}
