using SQLHelper;
using System;

namespace CallQueue.Core
{
    public class UnitOfWork
    {
        public readonly ISQLHelper SQLHelper;

        public UnitOfWork(ISQLHelper sqlHelper)
        {
            SQLHelper = sqlHelper;
            accountRepository = new Lazy<AccountRepository>(() => new AccountRepository(SQLHelper));
            callHistoryRepository = new Lazy<CallHistoryRepository>(() => new CallHistoryRepository(SQLHelper));
            counterRepository = new Lazy<CounterRepository>(() => new CounterRepository(SQLHelper));
            permissionRepository = new Lazy<PermissionRepository>(() => new PermissionRepository(SQLHelper));
            queueRepository = new Lazy<QueueRepository>(() => new QueueRepository(SQLHelper));
            roleRepository = new Lazy<RoleRepository>(() => new RoleRepository(SQLHelper));
            serviceRepository = new Lazy<ServiceRepository>(() => new ServiceRepository(SQLHelper));
        }

        readonly Lazy<AccountRepository> accountRepository;
        readonly Lazy<CallHistoryRepository> callHistoryRepository;
        readonly Lazy<CounterRepository> counterRepository;
        readonly Lazy<PermissionRepository> permissionRepository;
        readonly Lazy<QueueRepository> queueRepository;
        readonly Lazy<RoleRepository> roleRepository;
        readonly Lazy<ServiceRepository> serviceRepository;

        public AccountRepository AccountRepository { get { return accountRepository.Value; } }
        public CallHistoryRepository CallHistoryRepository { get { return callHistoryRepository.Value; } }
        public CounterRepository CounterRepository { get { return counterRepository.Value; } }
        public PermissionRepository PermissionRepository { get { return permissionRepository.Value; } }
        public QueueRepository QueueRepository { get { return queueRepository.Value; } }
        public RoleRepository RoleRepository { get { return roleRepository.Value; } }
        public ServiceRepository ServiceRepository { get { return serviceRepository.Value; } }
    }
}
