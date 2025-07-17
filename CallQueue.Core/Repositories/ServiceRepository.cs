using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SQLHelper;

namespace CallQueue.Core
{
    public class ServiceRepository : RepositoryBase<Service, int>
    {
        protected ISQLHelper sqlHelper;

        public ServiceRepository(ISQLHelper sqlHelper) : base(sqlHelper)
        {
            this.sqlHelper = sqlHelper;
        }

        public override int Delete(int primaryKey)
        {
            return sqlHelper.ExecuteNonQuery($"delete from service where Id = {primaryKey}");
        }

        public override int Delete(Service entity)
        {
            return Delete(entity.Id);
        }

        public override List<Service> GetAll()
        {
            return GetBySQLQuery($"select * from service");
        }

        public override DataTable GetAllData()
        {
            return sqlHelper.ExecuteQuery($"select * from service");
        }

        public override Service GetByPrimaryKey(int primaryKey)
        {
            return GetBySQLQuery($"select * from service where Id = {primaryKey}").FirstOrDefault();
        }

        public override List<Service> GetBySQLQuery(string query)
        {
            List<Service> services = new List<Service>();
            DataTable dt = sqlHelper.ExecuteQuery(query);
            if (dt != null)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    Service service = new Service()
                    {
                        Id = int.Parse(dtRow["Id"].ToString()),
                        Name = dtRow["Name"].ToString(),
                        Description = dtRow["Description"].ToString(),
                        CurrentNumber = int.Parse(dtRow["CurrentNumber"].ToString()),
                        PrintedNumber = int.Parse(dtRow["PrintedNumber"].ToString()),
                        PiorityLevel = int.Parse(dtRow["PiorityLevel"].ToString()),
                        TotalUseCount = int.Parse(dtRow["TotalUseCount"].ToString()),
                        UseCountOfDay = int.Parse(dtRow["UseCountOfDay"].ToString()),
                        UseCountOfWeek = int.Parse(dtRow["UseCountOfWeek"].ToString()),
                        UseCountOfMonth = int.Parse(dtRow["UseCountOfMonth"].ToString()),
                        UseCountOfYear = int.Parse(dtRow["UseCountOfYear"].ToString()),
                        Mark = dtRow["Mark"].ToString(),
                        InputPin = int.Parse(dtRow["InputPin"].ToString()),
                    };
                    services.Add(service);
                }
            }
            return services;
        }

        public override int Insert(Service entity)
        {
            return sqlHelper.ExecuteNonQuery($"insert into service (Name, Description, PiorityLevel, Mark, InputPin) values ('{entity.Name}', '{entity.Description}', {entity.PiorityLevel}, '{entity.Mark}', {entity.InputPin})");
        }

        public override int Update(Service entity)
        {
            return sqlHelper.ExecuteNonQuery($"update service set " +
                $"Name = '{entity.Name}', " +
                $"Description = '{entity.Description}', " +
                $"PiorityLevel = {entity.PiorityLevel}, " +
                $"Mark = '{entity.Mark}', " +
                $"InputPin = {entity.InputPin} " +
                $"where Id = {entity.Id}");
        }
    }
}
