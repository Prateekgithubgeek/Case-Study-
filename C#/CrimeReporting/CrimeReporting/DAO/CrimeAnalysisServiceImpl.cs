using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using entity;

using util;

namespace dao
{
    public class CrimeAnalysisServiceImpl : ICrimeAnalysisService
    {
        private SqlConnection connection;

        public CrimeAnalysisServiceImpl()
        {
            connection = DBConnUtil.GetConnection();
        }

        public bool CreateIncident(Incident incident)
        {
            string query = "INSERT INTO Incidents (IncidentType, IncidentDate, Latitude, Longitude, Description, Status, VictimID, SuspectID) VALUES (@type, @date, @lat, @lon, @desc, @status, @victimId, @suspectId)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@type", incident.IncidentType);
                command.Parameters.AddWithValue("@date", incident.IncidentDate);
                command.Parameters.AddWithValue("@lat", incident.Latitude);
                command.Parameters.AddWithValue("@lon", incident.Longitude);
                command.Parameters.AddWithValue("@desc", incident.Description);
                command.Parameters.AddWithValue("@status", incident.Status);
                command.Parameters.AddWithValue("@victimId", incident.VictimID);
                command.Parameters.AddWithValue("@suspectId", incident.SuspectID);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
                return result > 0;
            }
        }

        public bool UpdateIncidentStatus(string status, int incidentId)
        {
            string query = "UPDATE Incidents SET Status = @status WHERE IncidentID = @id";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@status", status);
                command.Parameters.AddWithValue("@id", incidentId);

                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();
                return result > 0;
            }
        }

        public IEnumerable<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT * FROM Incidents WHERE IncidentDate BETWEEN @start AND @end";
            List<Incident> incidents = new List<Incident>();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@start", startDate);
                command.Parameters.AddWithValue("@end", endDate);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    incidents.Add(new Incident
                    {
                        IncidentID = (int)reader["IncidentID"],
                        IncidentType = reader["IncidentType"].ToString(),
                        IncidentDate = (DateTime)reader["IncidentDate"],
                        Latitude = (double)reader["Latitude"],
                        Longitude = (double)reader["Longitude"],
                        Description = reader["Description"].ToString(),
                        Status = reader["Status"].ToString(),
                        VictimID = (int)reader["VictimID"],
                        SuspectID = (int)reader["SuspectID"]
                    });
                }
                connection.Close();
            }
            return incidents;
        }

        public IEnumerable<Incident> SearchIncidents(string criteria)
        {
            string query = "SELECT * FROM Incidents WHERE IncidentType LIKE @criteria";
            List<Incident> incidents = new List<Incident>();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@criteria", "%" + criteria + "%");

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    incidents.Add(new Incident
                    {
                        IncidentID = (int)reader["IncidentID"],
                        IncidentType = reader["IncidentType"].ToString(),
                        IncidentDate = (DateTime)reader["IncidentDate"],
                        Latitude = (double)reader["Latitude"],
                        Longitude = (double)reader["Longitude"],
                        Description = reader["Description"].ToString(),
                        Status = reader["Status"].ToString(),
                        VictimID = (int)reader["VictimID"],
                        SuspectID = (int)reader["SuspectID"]
                    });
                }
                connection.Close();
            }
            return incidents;
        }

        public Report GenerateIncidentReport(Incident incident)
        {
            // Implement the report generation logic
            return new Report();
        }
    }
}
