using AutoFixture;
using Moq.AutoMock;
using OnTheBeachTechnicalTest;
using OnTheBeachTechnicalTest.Implementation.HolidaySearcher;
using OnTheBeachTechnicalTest.Implementation.Models;
using OnTheBeachTechTest;
using FluentAssertions;

using Xunit;

namespace OnTheBeachTest

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
            flight.Id = 2;
            flight.Airline = "Oceanic Airlines";
            flight.From = "MAN";
            flight.To = "AGP";
            flight.Price = 245;
            flight.DepartureDate = "2023-07-01";

            var hotel = _fixture.Create<Hotel>();
            hotel.Id = 9;
            hotel.Name = "Nh Malaga";
            hotel.PricePerNight = 83;
            hotel.ArrivalDate = "2023-07-01";
            hotel.LocalAirports = new List<string> { "AGP" };
            hotel.Nights = 7;

            var flightServiceMock = _autoMocker.GetMock<IFlightService>();
            flightServiceMock.Setup(f => f.GetFilteredFlights("MAN", "AGP", "2023-07-01"))
                .Returns([flight]);

            var hotelServiceMock = _autoMocker.GetMock<IHotelService>();
            hotelServiceMock.Setup(h => h.GetFilteredHotels("AGP", "2023-07-01", 7)).Returns([hotel]);

            var holidaySearch = _autoMocker.CreateInstance<HolidaySearch>();
            
            //act
            var result = holidaySearch.Results.First();

            //assert
            var expectedTotalPrice = flight.Price + (hotel.PricePerNight * hotel.Nights);

            result.Flight.Should().BeEquivalentTo(flight);
            result.Hotel.Should().BeEquivalentTo(hotel);
            result.TotalPrice.Should().Be(expectedTotalPrice);
        }
        
    }
}

