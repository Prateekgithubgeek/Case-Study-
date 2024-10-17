using System;

namespace CrimeAnalysisSystem.Utilities
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString(string fileName)
        {
            // Replace with actual logic to load connection properties
            return "Server=localhost;Database=CrimeIncidentDBps;Integrated Security=True;";
        }
    }
}
