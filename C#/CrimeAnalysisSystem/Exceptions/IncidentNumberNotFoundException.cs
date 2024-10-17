using System;

namespace CrimeAnalysisSystem.Exceptions
{
    public class IncidentNumberNotFoundException : Exception
    {
        public IncidentNumberNotFoundException(string message) : base(message) { }
    }
}
