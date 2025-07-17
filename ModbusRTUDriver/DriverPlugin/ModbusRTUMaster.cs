using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class ModbusRTUMaster
    {
        private readonly SerialPort serialPort;

        private static readonly object key = new object();

        public bool IsOpen => serialPort.IsOpen;

        public ModbusRTUMaster()
        {
            this.serialPort = new SerialPort();

            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;
        }

        ~ModbusRTUMaster()
        {
            serialPort.Dispose();
        }

        public int Connect(Channel channel)
        {
            serialPort.PortName = channel.PortName;
            serialPort.BaudRate = channel.BaudRate;
            serialPort.DataBits = channel.DataBits;
            serialPort.Parity = channel.Parity;
            serialPort.StopBits = channel.StopBits;

            if (serialPort.IsOpen) return -1;

            try
            {
                serialPort.Open();
                return 0;
            }
            catch { return -1; }
        }

        public int Disconnect()
        {
            if (!serialPort.IsOpen) return -1;

            try
            {
                serialPort.Close();
                return 0;
            }
            catch { return -1; }
        }

        private byte[] GetCRC(byte[] message)
        {
            byte[] CRC = new byte[2];
            ushort CRCFull = 0xFFFF;
            char CRCLSB;

            for (int i = 0; i < (message.Length) - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ message[i]);

                for (int j = 0; j < 8; j++)
                {

                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1) CRCFull = (ushort)(CRCFull ^ 0xA001);
                }
            }
            CRC[1] = (byte)((CRCFull >> 8) & 0xFF);
            CRC[0] = (byte)(CRCFull & 0xFF);

            return CRC;
        }

        private byte[] BuildReaderMessage(byte deviceID, byte area, ushort startRegister, ushort numberOfRegisters)
        {
            byte[] message = new byte[8];

            message[0] = deviceID;
            message[1] = area;
            message[2] = (byte)(startRegister >> 8);
            message[3] = (byte)startRegister;
            message[4] = (byte)(numberOfRegisters >> 8);
            message[5] = (byte)numberOfRegisters;
            byte[] CRC = GetCRC(message);
            message[6] = CRC[0];
            message[7] = CRC[1];

            return message;
        }

        private bool CheckResponse(byte[] response)
        {
            byte[] CRC = GetCRC(response);
            return CRC[0] == response[response.Length - 2] && CRC[1] == response[response.Length - 1] ? true : false;
        }

        private void GetResponse(ref byte[] response)
        {
            for (int i = 0; i < response.Length; i++)
            {
                response[i] = (byte)(serialPort.ReadByte());
            }
        }

        public int WriteSingleCoil(byte deviceID, ushort startRegister, bool value)
        {
            try
            {
                if (!serialPort.IsOpen) return -1;

                lock (key)
                {
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();

                    byte[] message = new byte[8];
                    byte[] response = new byte[8];

                    message[0] = deviceID;
                    message[1] = 5;
                    message[2] = (byte)(startRegister >> 8);
                    message[3] = (byte)startRegister;
                    if (value) message[4] = (byte)(0xFF);
                    else message[4] = 0;
                    message[5] = 0;
                    byte[] CRC = GetCRC(message);
                    message[6] = CRC[0];
                    message[7] = CRC[1];

                    serialPort.Write(message, 0, message.Length);
                    GetResponse(ref response);

                    if (!CheckResponse(response)) return -1;

                    for (int i = 0; i < response.Length; i++)
                    {
                        if (response[i] != message[i]) return -1;
                    }

                    return 0;
                }
            }
            catch { return -1; }
        }

        public int WriteMultipleCoils(byte deviceID, ushort startRegister, ushort coils, bool[] values)
        {
            try
            {
                if (!serialPort.IsOpen) return -1;

                lock (key)
                {
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();

                    int dbytes = 0;
                    if ((coils % 8) > 0) dbytes = coils / 8 + 1;
                    else dbytes = coils / 8;

                    byte[] message = new byte[9 + dbytes];
                    byte[] response = new byte[8];

                    message[0] = deviceID;
                    message[1] = 15;
                    message[2] = (byte)(startRegister >> 8);
                    message[3] = (byte)startRegister;
                    message[4] = (byte)(coils >> 8);
                    message[5] = (byte)coils;
                    message[6] = (byte)dbytes;

                    int k = 0;
                    if ((coils / 8) < dbytes) k = dbytes * 8 - coils;

                    for (int i = 0; i < coils / 8; i++)
                    {
                        message[7 + i] = 0;
                        for (int j = 0; j < 8; j++)
                        {
                            message[7 + i] = Convert.ToByte(Convert.ToByte(values[8 * i + 7 - j]) | (message[7 + i] << 1));
                        }
                    }

                    for (int i = coils / 8; i < dbytes; i++)
                    {
                        message[7 + i] = 0;
                        for (int j = k; j < 8; j++)
                        {
                            message[7 + i] = Convert.ToByte(Convert.ToByte(values[8 * i + 7 - j]) | (message[7 + i] << 1));
                        }
                    }

                    byte[] CRC = GetCRC(message);
                    message[message.Length - 2] = CRC[0];
                    message[message.Length - 1] = CRC[1];

                    serialPort.Write(message, 0, message.Length);
                    GetResponse(ref response);

                    if (!CheckResponse(response)) return -1;

                    for (int i = 0; i < 6; i++)
                    {
                        if (response[i] != message[i]) return -1;
                    }

                    return 0;
                }
            }
            catch { return -1; }
        }

        public int WriteHoldingRegisters(byte deviceID, ushort startRegister, ushort numberOfRegisters, byte[] values)
        {
            try
            {
                if (!serialPort.IsOpen) return -1;

                lock (key)
                {
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();

                    byte[] message = new byte[9 + 2 * numberOfRegisters];
                    byte[] response = new byte[8];

                    message[0] = deviceID;
                    message[1] = 16;
                    message[2] = (byte)(startRegister >> 8);
                    message[3] = (byte)startRegister;
                    message[4] = (byte)(numberOfRegisters >> 8);
                    message[5] = (byte)numberOfRegisters;
                    message[6] = (byte)(numberOfRegisters * 2);
                    for (int i = 0; i < numberOfRegisters; i++)
                    {
                        message[7 + 2 * i] = values[2 * i];
                        message[8 + 2 * i] = values[2 * i + 1];
                    }
                    byte[] CRC = GetCRC(message);
                    message[message.Length - 2] = CRC[0];
                    message[message.Length - 1] = CRC[1];

                    serialPort.Write(message, 0, message.Length);
                    GetResponse(ref response);

                    if (!CheckResponse(response)) return -1;

                    return 0;
                }
            }
            catch { return -1; }
        }

        public byte[] ReadBytes(Address address, ushort numberOfResgister)
        {
            try
            {
                if (!serialPort.IsOpen) return null;

                lock (key)
                {
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();

                    byte[] message = address.Area < 3 ?
                        BuildReaderMessage(address.DeviceID, address.Area, address.Start, (ushort)(numberOfResgister * 16)) :
                        BuildReaderMessage(address.DeviceID, address.Area, address.Start, (ushort)(numberOfResgister));

                    byte[] response = new byte[5 + numberOfResgister * 2];
                    byte[] values = new byte[numberOfResgister * 2];

                    serialPort.Write(message, 0, message.Length);

                    GetResponse(ref response);
                    if (!CheckResponse(response)) return null;

                    if (response.Length == 6) values[0] = response[3];
                    else
                    {
                        for (int i = 0; i < (response.Length - 5) / 2; i++)
                        {
                            values[2 * i] = response[2 * i + 3];
                            values[2 * i + 1] = response[2 * i + 4];
                        }
                    }

                    return values;
                }
            }
            catch { return null; }
        }
    }
}
