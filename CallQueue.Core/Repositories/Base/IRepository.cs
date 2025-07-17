using System.Collections.Generic;
using System.Data;

namespace CallQueue.Core
{
    interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        List<TEntity> GetAll();
        DataTable GetAllData();
        List<TEntity> GetBySQLQuery(string query);
        TEntity GetByPrimaryKey(TPrimaryKey primaryKey);

        int Insert(TEntity entity);
        int Update(TEntity entity);
        int Delete(TPrimaryKey primaryKey);
        int Delete(TEntity entity);
    }
}
