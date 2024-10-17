using System.Data.SqlClient;

namespace CrimeAnalysisSystem.Utilities
{
    public static class DBConnUtil
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = DBPropertyUtil.GetConnectionString("db.properties");
            return new SqlConnection(connectionString);
        }
    }
}
