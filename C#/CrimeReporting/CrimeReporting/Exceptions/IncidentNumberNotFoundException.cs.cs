using System;

namespace exception
{
    public class IncidentNumberNotFoundException : Exception
    {
        public IncidentNumberNotFoundException(string message) : base(message) { }
    }
}
