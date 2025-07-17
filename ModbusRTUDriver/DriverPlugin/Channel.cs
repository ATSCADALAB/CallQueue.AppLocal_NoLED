using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class Channel
    {
        public string PortName { get; set; }

        public int BaudRate { get; set; }

        public int DataBits { get; set; }

        public Parity Parity { get; set; }

        public StopBits StopBits { get; set; }

        public Channel(string parametter)
        {
            var parametterArray = parametter.Split('.');

            PortName = parametterArray[0];

            _ = int.TryParse(parametterArray[1], out int baudRate);
            BaudRate = baudRate;

            _ = int.TryParse(parametterArray[2], out int dataBits);
            DataBits = dataBits;

            _ = Enum.TryParse(parametterArray[3], out Parity parity);
            Parity = parity;

            _ = Enum.TryParse(parametterArray[4], out StopBits stopBits);
            StopBits = stopBits;
        }
    }
}
