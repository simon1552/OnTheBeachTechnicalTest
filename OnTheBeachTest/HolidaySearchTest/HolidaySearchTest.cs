using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using OnTheBeachTechnicalTest;
using OnTheBeachTechnicalTest.Implementation.HolidaySearcher;
using OnTheBeachTechnicalTest.Implementation.Models;
using OnTheBeachTechTest;

namespace OnTheBeachTest.HolidaySearchTest

{
    public class HolidaySearchTest
    {
        public Fixture _fixture = new Fixture();
        public AutoMocker _autoMocker = new AutoMocker();
        
        [Test]
        public void GivenIHaveAFlightAndHotel_WhenISearchForHoliday_ThenCalculateTotalPrice()
        // what I want is to test the total price of the model
        {
            //arrange
            var flight = _fixture.Create<Flight>();

            var hotel = _fixture.Create<Hotel>();

            var flightServiceMock = _autoMocker.GetMock<IFlightService>();
            flightServiceMock.Setup(f => f.GetFilteredFlights("MAN", "AGP", "2023-07-01"))
                .Returns([flight]);

            var hotelServiceMock = _autoMocker.GetMock<IHotelService>();
            hotelServiceMock.Setup(h => h.GetFilteredHotels("AGP", "2023-07-01", 7)).Returns([hotel]);

            var holidaySearch = _autoMocker.CreateInstance<HolidaySearchService>();
            
            var searchCriteria = _fixture.Create<HolidaySearch>();
            searchCriteria.DepartingFrom = "MAN";
            searchCriteria.TravelingTo = "AGP";
            searchCriteria.DepartureDate = "2023-07-01";
            searchCriteria.Duration = 7;
            
            //act
            var results = holidaySearch.SearchHolidays(searchCriteria);
            var result = results.First();

            //assert
            var expectedTotalPrice = flight.Price + (hotel.PricePerNight * hotel.Nights);

            result.Flight.Should().BeEquivalentTo(flight);
            result.Hotel.Should().BeEquivalentTo(hotel);
            result.TotalPrice.Should().Be(expectedTotalPrice);
        }
        
    }
}

