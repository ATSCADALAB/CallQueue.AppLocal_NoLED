using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModbusRTUDriver
{
    public class ModbusRTUDispatcher : IDispatcher
    {
        private readonly int maxData = 252;

        private int updateRate = 200;

        private CancellationTokenSource cancellation;

        private readonly List<GroupAddress> groupAddresses;

        private readonly IConnector connector;

        public bool IsActive { get; private set; }

        public int UpdateRate
        {
            get => this.updateRate;
            set
            {
                if (value < 0) return;
                this.updateRate = value;
            }
        }

        public ModbusRTUDispatcher(IConnector connector)
        {
            this.connector = connector;
            this.groupAddresses = new List<GroupAddress>();
        }

        public void StartRead()
        {
            if (IsActive) return;
            try
            {
                this.cancellation = new CancellationTokenSource();
                TaskRead();
            }
            catch { }
        }

        public void StopRead()
        {
            if (!IsActive) return;
            try
            {
                this.cancellation.Cancel();
                this.cancellation.Dispose();
            }
            catch { }
        }

        private async void TaskRead()
        {
            IsActive = true;
            var token = this.cancellation.Token;

            await Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        TryConnect();


                        WriteTag();

                        ReadMultiTag();

                        if (token.IsCancellationRequested)
                        {
                            IsActive = false;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    IsActive = false;
                }
            }, token).ConfigureAwait(false);
        }

        private void TryConnect()
        {
            while (this.connector.AllowAutoConnect)
            {
                if (this.connector.IsConnected) break;

                this.connector.CloseConnector();
                Thread.Sleep(2000);

                this.connector.OpenConnector();
                Thread.Sleep(2000);
            }
        }

        private void WriteTag()
        {
            var count = this.connector.Writer.Count;

            while (count > 0)
            {
                object[] item = this.connector.Writer.Dequeue();
               
                if (item[0] is Func<int> writeFunc)
                {
                    var qualityRead = writeFunc();
                    if (qualityRead == -1 && (bool)item[1])
                        this.connector.Writer.Enqueue(item);

                    Thread.Sleep(200);
                }

                count--;
            }
        }

        private void ReadMultiTag()
        {
            var tags = this.connector.Management.GetAllTag();
            tags.Sort();
            this.groupAddresses.Clear();

            UpdateGroupAddress(tags);

            foreach (var groupAddress in this.groupAddresses)
            {
                var valueRead = this.connector.DataIO.ReadBytes(groupAddress.StartAddress, groupAddress.NumberOfRegister);
                this.connector.Reader.DataCache = valueRead;

                for (int i = 0; i < groupAddress.CountTag; i++)
                {
                    var tag = tags[groupAddress.IndexOfStartAddress + i];

                    var result = tag.Read(DataSource.Cache);
                    tag.Update(result);
                }

                Thread.Sleep(UpdateRate);
            }
        }

        private void UpdateGroupAddress(List<ITag> tags)
        {
            var count = tags.Count;
            if (count == 0) return;
            if (count == 1)
            {
                var address = tags[0].Address;
                this.groupAddresses.Add(new GroupAddress(address, 0, address.DataSize, 1));
                return;
            }

            var startAddress = Address.Empty;
            int indexOfStartAddress = 0;
            ushort numberOfRegister = 0;
            int countTagInGroup = 0;

            for (int index = 0; index < count; index++)
            {
                var address = tags[index].Address;

                if (countTagInGroup == 0)
                {
                    startAddress = address;
                    indexOfStartAddress = index;

                    address.IndexInCache = 0;
                    tags[index].Address = address;
                    countTagInGroup++;
                    continue;
                }

                ushort offset = GetOffsetAddress(startAddress, address);

                if (index == count - 1)
                {
                    if (offset + address.DataSize > this.maxData)
                    {
                        this.groupAddresses.Add(new GroupAddress(
                        startAddress,
                        indexOfStartAddress,
                        numberOfRegister,
                        countTagInGroup));

                        address.IndexInCache = 0;
                        tags[index].Address = address;
                        this.groupAddresses.Add(new GroupAddress(address, 0, address.DataSize, 1));
                        break;
                    }

                    address.IndexInCache = offset * 2;
                    tags[index].Address = address;
                    numberOfRegister = (ushort)(offset + address.DataSize);

                    this.groupAddresses.Add(new GroupAddress(
                        startAddress,
                        indexOfStartAddress,
                        numberOfRegister,
                        countTagInGroup + 1));
                    break;
                }

                if (offset + address.DataSize > this.maxData)
                {
                    this.groupAddresses.Add(new GroupAddress(
                        startAddress,
                        indexOfStartAddress,
                        numberOfRegister,
                        countTagInGroup));

                    countTagInGroup = 0;
                    index--;
                    continue;
                }

                numberOfRegister = (ushort)(offset + address.DataSize);
                address.IndexInCache = offset * 2;
                tags[index].Address = address;
                countTagInGroup++;
            }
        }

        private ushort GetOffsetAddress(Address beforeAddress, Address afterAddress)
        {
            if (beforeAddress.DeviceID == afterAddress.DeviceID && beforeAddress.Area == afterAddress.Area)
                return (ushort)(afterAddress.Start - beforeAddress.Start);
            return ushort.MaxValue - 8;
        }
    }
}
