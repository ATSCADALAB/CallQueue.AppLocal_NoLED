using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SQLHelper;

namespace CallQueue.Core
{
    public class AccountRepository : RepositoryBase<Account, int>
    {
        protected ISQLHelper sqlHelper;

        public AccountRepository(ISQLHelper sqlHelper) : base(sqlHelper)
        {
            this.sqlHelper = sqlHelper;
        }

        public override int Delete(int primaryKey)
        {
            return sqlHelper.ExecuteNonQuery($"delete from account where Id = {primaryKey}");
        }

        public override int Delete(Account entity)
        {
            return Delete(entity.Id);
        }

        public override List<Account> GetAll()
        {
            return GetBySQLQuery("select a.*, r.Name as RoleName from account a inner join role r on r.Id = a.RoleId");
        }

        public override DataTable GetAllData()
        {
            throw new NotImplementedException();
        }

        public override Account GetByPrimaryKey(int primaryKey)
        {
            return GetBySQLQuery($"select a.*, r.Name as RoleName from account a inner join role r on r.Id = a.RoleId where a.Id = {primaryKey}").FirstOrDefault();
        }

        public override List<Account> GetBySQLQuery(string query)
        {
            List<Account> accounts = new List<Account>();
            DataTable dt = sqlHelper.ExecuteQuery(query);
            if (dt != null)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    Account account = new Account()
                    {
                        Id = int.Parse(dtRow["Id"].ToString()),
                        Username = dtRow["Username"].ToString(),
                        Password = dtRow["Password"].ToString(),
                        RoleId = int.Parse(dtRow["RoleId"].ToString()),
                        RoleName = dtRow["RoleName"].ToString()
                    };
                    accounts.Add(account);
                }
            }
            return accounts;
        }

        public override int Insert(Account entity)
        {
            return sqlHelper.ExecuteNonQuery($"insert into account (Username, Password, RoleId) values ('{entity.Username}', '{entity.Password}', {entity.RoleId})");
        }

        public override int Update(Account entity)
        {
            return sqlHelper.ExecuteNonQuery($"update account set Username = '{entity.Username}', Password = '{entity.Password}', RoleId = {entity.RoleId} where Id = {entity.Id}");
        }

        public int VerityfyAccount(Account account)
        {
            return 0;
        }
    }
}
