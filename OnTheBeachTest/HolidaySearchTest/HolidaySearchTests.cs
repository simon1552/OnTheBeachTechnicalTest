using NUnit.Framework;
using OnTheBeachTechnicalTest;
using OnTheBeachTechnicalTest.Implementation.Models;

namespace OnTheBeachTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Search_Departing_From_MAN_Traveling_To_AGP()
        {
            
            //arrange
            var holidaySearch = new HolidaySearch("MAN", "AGP", "2023/07/01", 7);
            var result = holidaySearch.Results.First();
            
            //act
            
            
            //assert
            Assert.IsTrue(result.Flight.Id == 2 && result.Hotel.Id == 9);
            Assert.Equals(2, result.Flight.Id);
            Assert.Equals(9, result.Hotel.Id);
        }

        [Test]
        public void Search_Departing_From_ANY_Traveling_To_PMI()
        {
            var holidaySearch = new HolidaySearch("ANY", "PMI", "2023/06/15", 10);
            var result = holidaySearch.Results.First();
            Assert.IsTrue(result.Flight.Id == 6 && result.Hotel.Id == 5);
        }

        [Test]
        public void Search_Departing_From_ANY_Traveling_To_LPA()
        {
            var holidaySearch = new HolidaySearch("ANY", "PMI", "2022/11/10", 14);
            var result = holidaySearch.Results.First();
            Assert.IsTrue(result.Flight.Id == 7 && result.Hotel.Id == 6);
        }
    }
}
