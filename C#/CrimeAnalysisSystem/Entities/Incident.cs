using System;

namespace CrimeAnalysisSystem.Entities
{
    public class Incident
    {
        public int IncidentID { get; set; }
        public string IncidentType { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int VictimID { get; set; }
        public int SuspectID { get; set; }
    }
}
