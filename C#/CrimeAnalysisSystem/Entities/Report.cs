using System;

namespace CrimeAnalysisSystem.Entities
{
    public class Report
    {
        public int ReportID { get; set; }
        public int IncidentID { get; set; }
        public int ReportingOfficer { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportDetails { get; set; }
        public string Status { get; set; }
    }
}
