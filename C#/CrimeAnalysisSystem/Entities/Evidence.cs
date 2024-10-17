namespace CrimeAnalysisSystem.Entities
{
    public class Evidence
    {
        public int EvidenceID { get; set; }
        public string Description { get; set; }
        public string LocationFound { get; set; }
        public int IncidentID { get; set; }
    }
}
