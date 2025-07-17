using System;
using System.Collections.Generic;
using System.Data;
using SQLHelper;

namespace CallQueue.Core
{
    public class PermissionRepository : RepositoryBase<Permission, int>
    {
        public PermissionRepository(ISQLHelper sqlHelper) : base(sqlHelper)
        {
        }

        public override int Delete(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public override int Delete(Permission entity)
        {
            throw new NotImplementedException();
        }

        public override List<Permission> GetAll()
        {
            throw new NotImplementedException();
        }

        public override DataTable GetAllData()
        {
            throw new NotImplementedException();
        }

        public override Permission GetByPrimaryKey(int primaryKey)
        {
            throw new NotImplementedException();
        }

        public override List<Permission> GetBySQLQuery(string query)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Permission entity)
        {
            throw new NotImplementedException();
        }

        public override int Update(Permission entity)
        {
            throw new NotImplementedException();
        }
    }
}
