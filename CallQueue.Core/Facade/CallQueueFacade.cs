using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallQueue.Core.Facade
{
    public class CallQueueFacade
    {
        public ModbusManager ModbusManager { get; private set; }
        public PrinterManager PrinterManager { get; private set; }
        public QueueManager QueueManager { get; private set; }
        public VoiceManager VoiceManager { get; private set; }

        public CallQueueFacade(
            ModbusManager modbusManager, 
            PrinterManager printerManager, 
            QueueManager queueManager, 
            VoiceManager voiceManager)
        {
            ModbusManager = modbusManager;
            PrinterManager = printerManager;
            QueueManager = queueManager;
            VoiceManager = voiceManager;
        }
    }
}
