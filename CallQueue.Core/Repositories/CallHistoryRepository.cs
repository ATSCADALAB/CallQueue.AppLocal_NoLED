using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;

namespace CallQueue.Core
{
    public class CallHistoryRepository : RepositoryBase<CallHistory, int>
    {
        public CallHistoryRepository(ISQLHelper sqlHelper) : base(sqlHelper)
        {
        }

        public override int Delete(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public override int Delete(CallHistory entity)
        {
            throw new NotImplementedException();
        }

        public override List<CallHistory> GetAll()
        {
            throw new NotImplementedException();
        }

        public override DataTable GetAllData()
        {
            throw new NotImplementedException();
        }

        public override CallHistory GetByPrimaryKey(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public override List<CallHistory> GetBySQLQuery(string query)
        {
            throw new NotImplementedException();
        }

        public override int Insert(CallHistory entity)
        {
            throw new NotImplementedException();
        }

        public override int Update(CallHistory entity)
        {
            throw new NotImplementedException();
        }
    }
}
