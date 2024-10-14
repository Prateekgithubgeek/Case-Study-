namespace entity
{
    public class Incident
    {
        public int IncidentID { get; set; }
        public string IncidentType { get; set; }
        public DateTime IncidentDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int VictimID { get; set; }
        public int SuspectID { get; set; }

        public Incident() { }

        public Incident(int id, string type, DateTime date, double lat, double lon, string desc, string status, int victimId, int suspectId)
        {
            IncidentID = id;
            IncidentType = type;
            IncidentDate = date;
            Latitude = lat;
            Longitude = lon;
            Description = desc;
            Status = status;
            VictimID = victimId;
            SuspectID = suspectId;
        }
    }
}
