using CrimeAnalysisSystem.Entities;
using CrimeAnalysisSystem.Utilities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CrimeAnalysisSystem.DataAccess
{
    public class CrimeAnalysisServiceImpl : ICrimeAnalysisService
    {
        private SqlConnection _connection;

        public CrimeAnalysisServiceImpl()
        {
            _connection = DBConnUtil.GetConnection();
        }

        public bool CreateIncident(Incident incident)
        {
            try
            {
                string query = "INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID) " +
                               "VALUES (@IncidentType, @IncidentDate, @Location, @Description, @Status, @VictimID, @SuspectID)";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
                    command.Parameters.AddWithValue("@IncidentDate", incident.IncidentDate);
                    command.Parameters.AddWithValue("@Location", incident.Location);
                    command.Parameters.AddWithValue("@Description", incident.Description);
                    command.Parameters.AddWithValue("@Status", incident.Status);
                    command.Parameters.AddWithValue("@VictimID", incident.VictimID);
                    command.Parameters.AddWithValue("@SuspectID", incident.SuspectID);

                    _connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0; // Ensure this returns true if the insert was successful
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); // Log or handle the exception
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }


        public bool UpdateIncidentStatus(int incidentID, string status)
        {
            try
            {
                string query = "UPDATE Incidents SET Status = @Status WHERE IncidentID = @IncidentID";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@IncidentID", incidentID);

                    _connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception)
            {
                // Handle exceptions (logging, etc.)
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public IEnumerable<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incident> incidents = new List<Incident>();
            try
            {
                string query = "SELECT * FROM Incidents WHERE IncidentDate BETWEEN @StartDate AND @EndDate";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            incidents.Add(new Incident
                            {
                                IncidentID = reader.GetInt32(0),
                                IncidentType = reader.GetString(1),
                                IncidentDate = reader.GetDateTime(2),
                                Location = reader.GetString(3),
                                Description = reader.GetString(4),
                                Status = reader.GetString(5),
                                VictimID = reader.GetInt32(6),
                                SuspectID = reader.GetInt32(7)
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Handle exceptions (logging, etc.)
            }
            finally
            {
                _connection.Close();
            }
            return incidents;
        }

        public IEnumerable<Incident> SearchIncidents(string criteria)
        {
            List<Incident> incidents = new List<Incident>();
            try
            {
                string query = "SELECT * FROM Incidents WHERE IncidentType LIKE @Criteria OR Description LIKE @Criteria";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@Criteria", "%" + criteria + "%");

                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            incidents.Add(new Incident
                            {
                                IncidentID = reader.GetInt32(0),
                                IncidentType = reader.GetString(1),
                                IncidentDate = reader.GetDateTime(2),
                                Location = reader.GetString(3),
                                Description = reader.GetString(4),
                                Status = reader.GetString(5),
                                VictimID = reader.GetInt32(6),
                                SuspectID = reader.GetInt32(7)
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Handle exceptions (logging, etc.)
            }
            finally
            {
                _connection.Close();
            }
            return incidents;
        }

        public Report GenerateIncidentReport(Incident incident)
        {
            // Implement the logic to generate a report
            return new Report
            {
                IncidentID = incident.IncidentID,
                ReportDate = DateTime.Now,
                ReportDetails = "Report generated for incident ID: " + incident.IncidentID,
                Status = "Finalized",
                ReportingOfficer = 1 // Assuming a reporting officer ID
            };
        }
    }
}
