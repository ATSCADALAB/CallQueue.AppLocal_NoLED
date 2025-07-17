using SQLHelper;
using System.Collections.Generic;
using System.Data;

namespace CallQueue.Core
{
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        readonly ISQLHelper sqlHelper;
        public RepositoryBase(ISQLHelper sqlHelper)
        {
            this.sqlHelper = sqlHelper; 
        }
        public abstract List<TEntity> GetAll();
        public abstract List<TEntity> GetBySQLQuery(string query);
        public abstract int Delete(TPrimaryKey primaryKey);
        public abstract int Delete(TEntity entity);
        public abstract int Insert(TEntity entity);
        public abstract int Update(TEntity entity);
        public abstract TEntity GetByPrimaryKey(TPrimaryKey primaryKey);
        public abstract DataTable GetAllData();
    }
}
