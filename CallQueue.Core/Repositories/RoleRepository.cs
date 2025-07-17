using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;

namespace CallQueue.Core
{
    public class RoleRepository : RepositoryBase<Role, int>
    {
        protected ISQLHelper sqlHelper;

        public RoleRepository(ISQLHelper sqlHelper) : base(sqlHelper)
        {
            this.sqlHelper = sqlHelper;
        }

        public override int Delete(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public override int Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public override List<Role> GetAll()
        {
            List<Role> roles = new List<Role>();
            DataTable dt = sqlHelper.ExecuteQuery($"select * from role");
            if (dt != null)
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    Role role = new Role()
                    {
                        Id = int.Parse(dtRow["Id"].ToString()),
                        Name = dtRow["Name"].ToString(),
                        Level = int.Parse(dtRow["Level"].ToString())
                    };
                    roles.Add(role);
                }
            }
            return roles;
        }

        public override DataTable GetAllData()
        {
            throw new NotImplementedException();
        }

        public override Role GetByPrimaryKey(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public override List<Role> GetBySQLQuery(string query)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Role entity)
        {
            throw new NotImplementedException();
        }

        public override int Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
