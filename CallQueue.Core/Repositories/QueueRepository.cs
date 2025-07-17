using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;

namespace CallQueue.Core
{
    public class QueueRepository : RepositoryBase<Queue, int>
    {
        public QueueRepository(ISQLHelper sqlHelper) : base(sqlHelper)
        {
        }

        public override int Delete(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public override int Delete(Queue entity)
        {
            throw new NotImplementedException();
        }

        public override List<Queue> GetAll()
        {
            throw new NotImplementedException();
        }

        public override DataTable GetAllData()
        {
            throw new NotImplementedException();
        }

        public override Queue GetByPrimaryKey(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public override List<Queue> GetBySQLQuery(string query)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Queue entity)
        {
            throw new NotImplementedException();
        }

        public override int Update(Queue entity)
        {
            throw new NotImplementedException();
        }
    }
}
