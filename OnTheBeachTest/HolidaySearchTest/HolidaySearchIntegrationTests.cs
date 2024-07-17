using NUnit.Framework;
using OnTheBeachTechnicalTest;
using OnTheBeachTechnicalTest.Implementation.HolidaySearcher;
using OnTheBeachTechnicalTest.Implementation.Models;
using OnTheBeachTechnicalTest.Implementation.Repository;
using OnTheBeachTechnicalTest.Implementation.Service;

namespace OnTheBeachTest
{
    
    [TestFixture]
    public class HolidaySearchIntegrationTests
    {
        private IHolidaySearchService _holidaySearchService;

        
        [SetUp]
        public void Setup()
        {
            var flightService = new FlightService(new FlightRepository());
            var hotelService = new HotelService(new HotelRepository());
            _holidaySearchService = new HolidaySearchService(flightService, hotelService);
        }

        [Test]
        public void Search_Departing_From_MAN_Traveling_To_AGP()
        {
            // Arrange
            var holidaySearch = new HolidaySearch("MAN", "AGP", "2023-07-01", 7);
            
            // Act
            var results = _holidaySearchService.SearchHolidays(holidaySearch);
            var result = results.First();
            
            // Assert
            Assert.IsTrue(result.Flight.Id == 2 && result.Hotel.Id == 9);
        }

        [Test]
        public void Search_Departing_From_ANY_Traveling_To_PMI()
        {
            var holidaySearch = new HolidaySearch("ANY", "PMI", "2023-06-15", 10);
            
            var results = _holidaySearchService.SearchHolidays(holidaySearch);

            var result = results.First();
            Assert.IsTrue(result.Flight.Id == 6 && result.Hotel.Id == 5);
        }

        [Test]
        public void Search_Departing_From_ANY_Traveling_To_LPA()
        {
            var holidaySearch = new HolidaySearch("ANY", "PMI", "2022-11-10", 14);
            
            var results = _holidaySearchService.SearchHolidays(holidaySearch);
            var result = results.First();
            Assert.IsTrue(result.Flight.Id == 7 && result.Hotel.Id == 6);
        }
    }
}
