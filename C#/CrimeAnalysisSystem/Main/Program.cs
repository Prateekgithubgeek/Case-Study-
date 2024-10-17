using System;

using CrimeAnalysisSystem.DataAccess;
using CrimeAnalysisSystem.Entities;

namespace CrimeAnalysisSystem.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            ICrimeAnalysisService service = new CrimeAnalysisServiceImpl();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Crime Analysis and Reporting System");
                Console.WriteLine("1. Create Incident");
                Console.WriteLine("2. Update Incident Status");
                Console.WriteLine("3. Get Incidents in Date Range");
                Console.WriteLine("4. Search Incidents");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateIncident(service);
                        break;
                    case "2":
                        UpdateIncidentStatus(service);
                        break;
                    case "3":
                        GetIncidentsInDateRange(service);
                        break;
                    case "4":
                        SearchIncidents(service);
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        private static void CreateIncident(ICrimeAnalysisService service)
        {
            Console.WriteLine("Enter Incident Details:");

            var incident = new Incident();

            Console.Write("Incident Type: ");
            incident.IncidentType = Console.ReadLine();

            Console.Write("Incident Date (yyyy-mm-dd): ");
            incident.IncidentDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Location: ");
            incident.Location = Console.ReadLine();

            Console.Write("Description: ");
            incident.Description = Console.ReadLine();

            Console.Write("Status: ");
            incident.Status = Console.ReadLine();

            Console.Write("Victim ID: ");
            incident.VictimID = int.Parse(Console.ReadLine());

            Console.Write("Suspect ID: ");
            incident.SuspectID = int.Parse(Console.ReadLine());

            if (service.CreateIncident(incident))
            {
                Console.WriteLine("Incident created successfully!");
            }
            else
            {
                Console.WriteLine("Failed to create incident.");
            }
        }

        private static void UpdateIncidentStatus(ICrimeAnalysisService service)
        {
            Console.Write("Enter Incident ID to update: ");
            int incidentID = int.Parse(Console.ReadLine());

            Console.Write("Enter new status: ");
            string status = Console.ReadLine();

            if (service.UpdateIncidentStatus(incidentID, status))
            {
                Console.WriteLine("Incident status updated successfully!");
            }
            else
            {
                Console.WriteLine("Failed to update incident status.");
            }
        }

        private static void GetIncidentsInDateRange(ICrimeAnalysisService service)
        {
            Console.Write("Enter start date (yyyy-mm-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter end date (yyyy-mm-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            var incidents = service.GetIncidentsInDateRange(startDate, endDate);
            Console.WriteLine("Incidents in Date Range:");
            foreach (var incident in incidents)
            {
                Console.WriteLine($"ID: {incident.IncidentID}, Type: {incident.IncidentType}, Date: {incident.IncidentDate}, Status: {incident.Status}");
            }
        }

        private static void SearchIncidents(ICrimeAnalysisService service)
        {
            Console.Write("Enter search criteria (Type or Description): ");
            string criteria = Console.ReadLine();

            var incidents = service.SearchIncidents(criteria);
            Console.WriteLine("Search Results:");
            foreach (var incident in incidents)
            {
                Console.WriteLine($"ID: {incident.IncidentID}, Type: {incident.IncidentType}, Date: {incident.IncidentDate}, Status: {incident.Status}");
            }
        }
    }
}
