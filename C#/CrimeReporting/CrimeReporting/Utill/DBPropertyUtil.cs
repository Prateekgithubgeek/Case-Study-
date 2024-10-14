using System.IO;

namespace util
{
    public static class DBPropertyUtil
    {
        public static string GetPropertyString(string fileName)
        {
            // Read database connection properties from a properties file
            string connectionString = DBPropertyUtil.GetPropertyString("dbConfig.properties");

            string connectionString = "Server=localhost;Database=CrimeIncidentDBps;Integrated Security=True;";

            foreach (var line in lines)
            {
                if (line.StartsWith("ConnectionString"))
                {
                    connectionString = line.Split('=')[1].Trim();
                    break;
                }
            }
            return connectionString;
        }
    }
}
