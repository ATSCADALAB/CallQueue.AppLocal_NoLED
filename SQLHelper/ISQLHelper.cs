using System.Data;

namespace SQLHelper
{
    public interface ISQLHelper
    {
        string ConnectionString { get; set; }
        int ExecuteNonQuery(string query);
        int ExecuteNonQuery(string query, params object[] parameters);
        DataTable ExecuteQuery(string query);
        object ExecuteScalarQuery(string query);
    }
}
