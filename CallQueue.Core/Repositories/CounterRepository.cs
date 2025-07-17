using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;

namespace CallQueue.Core
{
    public class CounterRepository : RepositoryBase<Counter, int>
    {
        protected ISQLHelper sqlHelper;

        public CounterRepository(ISQLHelper sqlHelper) : base(sqlHelper)
        {
            this.sqlHelper = sqlHelper;
        }

        public override int Delete(int primaryKey)
        {
            return sqlHelper.ExecuteNonQuery($"delete from counter where Id = {primaryKey}");
        }

        public override int Delete(Counter entity)
        {
            return Delete(entity.Id);
        }

        public override List<Counter> GetAll()
        {
            return GetBySQLQuery($"select * from counter");
        }

        public override DataTable GetAllData()
        {
            return sqlHelper.ExecuteQuery($"select * from counter");
        }

        public override Counter GetByPrimaryKey(int primaryKey)
        {
            return GetBySQLQuery($"select * from counter where Id = {primaryKey}").FirstOrDefault();
        }

        public override List<Counter> GetBySQLQuery(string query)
        {
            List<Counter> counters = new List<Counter>();
            DataTable dt = sqlHelper.ExecuteQuery(query);
            if (dt != null)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    Counter counter = new Counter()
                    {
                        Id = int.Parse(dtRow["Id"].ToString()),
                        Name = dtRow["Name"].ToString(),
                        IsCalling = int.Parse(dtRow["IsCalling"].ToString()),
                        CallTime = dtRow["CallTime"].ToString(),
                        CurrentNumber = int.Parse(dtRow["CurrentNumber"].ToString()),
                        IsMaster = int.Parse(dtRow["IsMaster"].ToString()),
                        Voice = dtRow["Voice"].ToString(),
                        CurrentServiceId = int.Parse(dtRow["CurrentServiceId"].ToString()),
                        TotalServeCount = int.Parse(dtRow["TotalServeCount"].ToString()),
                        ServeCountOfDay = int.Parse(dtRow["ServeCountOfDay"].ToString()),
                        ServeCountOfWeek = int.Parse(dtRow["ServeCountOfWeek"].ToString()),
                        ServeCountOfMonth = int.Parse(dtRow["ServeCountOfMonth"].ToString()),
                        ServeCountOfYear = int.Parse(dtRow["ServeCountOfYear"].ToString()),
                        KeyboardId = dtRow["KeyboardId"].ToString(),
                        MasterKeyBoardId = string.IsNullOrEmpty(dtRow["MasterKeyBoardId"].ToString()) ? 0 : int.Parse(dtRow["MasterKeyBoardId"].ToString()),
                        AddressCallCommand = dtRow["AddressCallCommand"].ToString(),
                        AddressPiorityNumber = dtRow["AddressPiorityNumber"].ToString(),
                        AddressDisplayNumber = dtRow["AddressDisplayNumber"].ToString(),
                        AddressRemainNumber = dtRow["AddressRemainNumber"].ToString(),
                        AddressDisplayLedMode = dtRow["AddressDisplayLedMode"].ToString(),
                        AddressDisplayLedNumber = dtRow["AddressDisplayLedNumber"].ToString(),
                        DisplayLedId = dtRow["DisplayLedId"].ToString(),
                        MasterDisplayLedId = string.IsNullOrEmpty(dtRow["MasterDisplayLedId"].ToString()) ? 0 : int.Parse(dtRow["MasterDisplayLedId"].ToString()),
                    };
                    counters.Add(counter);
                }
            }
            return counters;
        }

        public override int Insert(Counter entity)
        {
            return sqlHelper.ExecuteNonQuery($"insert into counter (Name, Voice) values ('{entity.Name}', '{entity.Voice}')");
        }

        public override int Update(Counter entity)
        {
            return sqlHelper.ExecuteNonQuery($"update counter set Name = '{entity.Name}', Voice = '{entity.Voice}' where Id = {entity.Id}");
        }
    }
}
