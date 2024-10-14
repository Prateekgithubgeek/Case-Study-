using System;

using dao;

using entity;

namespace CrimeReporting
{
    class Program
    {
        static void Main(string[] args)
        {
            ICrimeAnalysisService crimeService = new CrimeAnalysisServiceImpl();
            while (true)
            {
                Console.WriteLine("1. Create Incident");
                Console.WriteLine("2. Update Incident Status");
                Console.WriteLine("3. Get Incidents in Date Range");
                Console.WriteLine("4. Search Incidents");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateIncident(crimeService);
                        break;
                    case 2:
                        UpdateIncidentStatus(crimeService);
                        break;
                    case 3:
                        GetIncidentsInDateRange(crimeService);
                        break;
                    case 4:
                        SearchIncidents(crimeService);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateIncident(ICrimeAnalysisService crimeService)
        {
            Console.Write("Enter Incident Type: ");
            string type = Console.ReadLine();
            Console.Write("Enter Incident Date (YYYY-MM-DD): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Latitude: ");
            double latitude = double.Parse(Console.ReadLine());
            Console.Write("Enter Longitude: ");
            double longitude = double.Parse(Console.ReadLine());
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Status: ");
            string status = Console.ReadLine();
            Console.Write("Enter Victim ID: ");
            int victimId = int.Parse(Console.ReadLine());
            Console.Write("Enter Suspect ID: ");
            int suspectId = int.Parse(Console.ReadLine());

            Incident incident = new Incident(0, type, date, latitude, longitude, description, status, victimId, suspectId);
            bool result = crimeService.CreateIncident(incident);
            Console.WriteLine(result ? "Incident created successfully." : "Failed to create incident.");
        }

        static void UpdateIncidentStatus(ICrimeAnalysisService crimeService)
        {
            Console.Write("Enter Incident ID: ");
            int incidentId = int.Parse(Console.ReadLine());
            Console.Write("Enter New Status: ");
            string status = Console.ReadLine();

            bool result = crimeService.UpdateIncidentStatus(status, incidentId);
            Console.WriteLine(result ? "Incident status updated successfully." : "Failed to update incident status.");
        }

        static void GetIncidentsInDateRange(ICrimeAnalysisService crimeService)
        {
            Console.Write("Enter Start Date (YYYY-MM-DD): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter End Date (YYYY-MM-DD): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            var incidents = crimeService.GetIncidentsInDateRange(startDate, endDate);
            foreach (var incident in incidents)
            {
                Console.WriteLine($"Incident ID: {incident.IncidentID}, Type: {incident.IncidentType}, Date: {incident.IncidentDate}");
            }
        }

        static void SearchIncidents(ICrimeAnalysisService crimeService)
        {
            Console.Write("Enter Search Criteria (Incident Type): ");
            string criteria = Console.ReadLine();

            var incidents = crimeService.SearchIncidents(criteria);
            foreach (var incident in incidents)
            {
                Console.WriteLine($"Incident ID: {incident.IncidentID}, Type: {incident.IncidentType}, Date: {incident.IncidentDate}");
            }
        }
    }
}
