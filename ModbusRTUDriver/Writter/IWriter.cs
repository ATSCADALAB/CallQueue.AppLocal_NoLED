﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ModbusRTUDriver
{
    public interface IWriter
    {       
        int Count { get; }

        void Enqueue(object[] item);

        object[] Dequeue();      
    }
}
