using System;

namespace CrimeAnalysisSystem.Entities
{
    public class Victim
    {
        public int VictimID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactInformation { get; set; }
    }
}
