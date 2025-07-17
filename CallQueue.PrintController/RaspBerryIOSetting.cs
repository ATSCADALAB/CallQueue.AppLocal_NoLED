using Raspberry.IO.GeneralPurpose;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallQueue.PrintController
{
    public partial class RaspBerryIOSetting : Component
    {
        #region Public methods

        public int UpdateInterval { get; set; } = 100;

        public static IGpioConnectionDriver Driver = GpioConnectionSettings.DefaultDriver;

        #endregion

        #region Private members

        List<Input> inputs = new List<Input>();
        List<Output> outputs = new List<Output>();

        Task readTask;
        object locker = new object();

        #endregion

        #region Constructors

        public RaspBerryIOSetting()
        {
            InitializeComponent();
        }

        public RaspBerryIOSetting(IContainer container) : base()
        {
            container.Add(this);
        }

        #endregion

        #region Public methods

        public void BeginRead()
        {
            foreach (var input in inputs)
            {
                Driver.Allocate(input.ProcessorPin, PinDirection.Input);
                Console.WriteLine($"Allocate input: {input.Name} - {input.ProcessorPin}");
            }
            foreach (var output in outputs)
            {
                Driver.Allocate(output.ProcessorPin, PinDirection.Output);
                Console.WriteLine($"Allocate output: {output.Name} - {output.ProcessorPin}");
            }

            readTask = new Task(ReadPins, CancellationToken.None, TaskCreationOptions.LongRunning);

            readTask.Start();
        }

        public Input AddInput(string name, ProcessorPin processorPin)
        {

            lock (locker)
            {
                Input input = new Input(name, processorPin);
                inputs.Add(input);
                return input;
            }
        }

        public Input AddInput(Input input)
        {
            lock (locker)
            {
                Console.WriteLine($"Lock");
                Console.WriteLine($"Begin add input");
                inputs.Add(input);
                Console.WriteLine($"Add input success.");
                return input;
            }
        }

        public Output AddOutput(string name, ProcessorPin processorPin)
        {
            lock (locker)
            {
                Output output = new Output(name, processorPin);
                outputs.Add(output);
                return output;
            }
        }

        public Output AddOutput(Output output)
        {
            lock (locker)
            {
                outputs.Add(output);
                return output;
            }
        }

        public bool Read(ProcessorPin processorPin)
        {
            lock (locker)
            {
                return Driver.Read(processorPin);
            }
        }

        public void Write(ProcessorPin processorPin, bool value)
        {
            lock (locker)
            {
                Driver.Write(processorPin, value);
            }
        }

        #endregion

        #region Private methods

        private void ReadPins()
        {
            //First load
            lock (locker)
            {
                foreach (var input in inputs)
                {
                    try
                    {
                        input.SetValue(input.Read(), false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

                foreach (var output in outputs)
                {
                    try
                    {
                        output.SetValue(output.Read(), false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            Thread.Sleep(UpdateInterval);

            while (true)
            {
                lock (locker)
                {
                    foreach (var input in inputs)
                    {
                        try
                        {
                            input.Value = input.Read();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }

                    foreach (var output in outputs)
                    {
                        try
                        {
                            output.Value = output.Read();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
                Thread.Sleep(UpdateInterval);
            }
        }

        #endregion

    }

    [Serializable]
    public abstract class Pin
    {
        public virtual string Name { get; set; }

        public ProcessorPin ProcessorPin;

        public PinDirection PinDirection;

        protected bool value;
        [Browsable(false)]
        public virtual bool Value
        {
            get { return value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    if (ValueChanged != null)
                        ValueChanged.Invoke(this, new IOValueChangedEventArgs(value));
                }
            }
        }

        public abstract bool Read();
        public abstract void Write(bool value);

        public virtual void SetValue(bool newValue, bool raiseValueChanged = true)
        {
            if (raiseValueChanged)
                Value = newValue;
            else
                value = newValue;
        }
        
        [field:NonSerialized]
        public event EventHandler<IOValueChangedEventArgs> ValueChanged;
    }

    [Serializable]
    public class Input : Pin
    {
        public Input()
        {
            PinDirection = PinDirection.Input;
        }

        public Input(string name, ProcessorPin processorPin) : base()
        {
            Name = name;
            ProcessorPin = processorPin;  
        }

        public override bool Read()
        {
            return RaspBerryIOSetting.Driver.Read(ProcessorPin);
        }

        public override void Write(bool value)
        {
        }
    }

    [Serializable]
    public class Output : Pin
    {
        public Output()
        {
            PinDirection = PinDirection.Output;
        }

        public Output(string name, ProcessorPin processorPin) : base()
        {
            Name = name;
            ProcessorPin = processorPin;
        }

        public override bool Read()
        {
            return RaspBerryIOSetting.Driver.Read(ProcessorPin);
        }

        public override void Write(bool value)
        {
            RaspBerryIOSetting.Driver.Write(ProcessorPin, value);
        }
    }

    public class IOValueChangedEventArgs : EventArgs
    {
        public bool NewValue { get; private set; }

        public IOValueChangedEventArgs(bool newValue)
        {
            NewValue = newValue;
        }
    }
}
