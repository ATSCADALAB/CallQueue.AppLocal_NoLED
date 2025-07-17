using CallQueue.Controls;
using CallQueue.Core;
using ModbusRTUDriver;
using Ninject;
using SQLHelper;

namespace CallQueue.AppLocal
{
    public class IoC
    {
        #region Instance

        public static IoC Instance { get; protected set; } = new IoC();

        #endregion

        public IKernel Kernal { get; protected set; } = new StandardKernel();
            
        public UnitOfWork UnitOfWork { get { return Get<UnitOfWork>(); } }

        public ISQLHelper SQLHelper { get { return Get<ISQLHelper>(); } }

        public CallVoice MainCallVoice { get { return Get<CallVoice>(); } }

        public QueueManager QueueManager { get { return Get<QueueManager>(); } }

        public PrinterManager PrinterSetting { get { return Get<PrinterManager>(); } }

        public ModbusManager ModbusManager { get { return Get<ModbusManager>(); } }

        public VoiceManager VoiceManager { get { return Get<VoiceManager>(); } }

        public IConnector Connector { get { return Get<IConnector>(); } }

        public string ConnectionString { get; set; }

        public void Setup()
        {
            ConnectionString = Properties.Settings.Default["constr"].ToString();
            Kernal.Bind<ISQLHelper>().ToConstant(new MySQLHelper() { ConnectionString = ConnectionString });
            Kernal.Bind<QueueManager>().To<QueueManager>().InSingletonScope();
            Kernal.Bind<VoiceManager>().To<VoiceManager>().InSingletonScope();
            Kernal.Bind<PrinterManager>().To<PrinterManager>().InSingletonScope();
            Kernal.Bind<ModbusManager>().To<ModbusManager>().InSingletonScope();
            Kernal.Bind<UnitOfWork>().ToConstant(new UnitOfWork(Get<ISQLHelper>()));
        }

        public T Get<T>()
        {
            return Kernal.Get<T>();
        }
    }
}
