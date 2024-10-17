using CrimeAnalysisSystem.Entities;

using System;
using System.Collections.Generic;

namespace CrimeAnalysisSystem.DataAccess
{
    public interface ICrimeAnalysisService
    {
        bool CreateIncident(Incident incident);
        bool UpdateIncidentStatus(int incidentID, string status);
        IEnumerable<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Incident> SearchIncidents(string criteria);
        Report GenerateIncidentReport(Incident incident);
    }
}
