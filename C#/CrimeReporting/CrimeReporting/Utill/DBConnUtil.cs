using System.Data.SqlClient;

namespace util
{
    public static class DBConnUtil
    {
        private static SqlConnection connection;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = DBPropertyUtil.GetPropertyString("dbConfig.properties");
                connection = new SqlConnection(Server = localhost; Database = CrimeIncidentDBps; Integrated Security = True; ;)
            }
            return connection;
        }
    }
}
