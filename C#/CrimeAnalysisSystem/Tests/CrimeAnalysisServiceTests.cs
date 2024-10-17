//using NUnit.Framework;
//using CrimeAnalysisSystem.DataAccess;
//using CrimeAnalysisSystem.Entities;
//using System;

//namespace CrimeAnalysisSystem.Tests
//{
//    [TestFixture]
//    public class CrimeAnalysisServiceTests
//    {
//        private ICrimeAnalysisService _service;

//        [SetUp]
//        public void Setup()
//        {
//            _service = new CrimeAnalysisServiceImpl();
//        }

//        [Test]
//        public void Test_CreateIncident()
//        {
//            var incident = new Incident
//            {
//                IncidentID = 1,
//                IncidentType = "Robbery",
//                IncidentDate = DateTime.Now,
//                Location = "Location1",
//                Description = "Test description",
//                Status = "Open",
//                VictimID = 1,
//                SuspectID = 1
//            };
//            var result = _service.CreateIncident(incident);
//            Assert.IsTrue(result);
//        }
//    }
//}
