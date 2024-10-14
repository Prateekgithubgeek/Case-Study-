using System;
using System.Collections.Generic;

using entity;

namespace dao
{
    public interface ICrimeAnalysisService
    {
        bool CreateIncident(Incident incident);
        bool UpdateIncidentStatus(string status, int incidentId);
        IEnumerable<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<Incident> SearchIncidents(string criteria);
        Report GenerateIncidentReport(Incident incident);
        // Methods related to cases can be added here
    }
}
