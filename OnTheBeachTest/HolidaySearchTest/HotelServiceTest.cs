using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using OnTheBeachTechnicalTest.Implementation.Service;
using OnTheBeachTechTest;
using Xunit;

namespace OnTheBeachTest.HolidaySearchTest;

public class HotelServiceTest
{
    public Fixture _fixture = new Fixture();
    public AutoMocker _autoMocker = new AutoMocker();

    [Test]
    public void GivenHotelRepository_WhenGetFilteredHotels_ThenReturnHotels()
    {
        //arrange
        var hotelRepoMock = _autoMocker.GetMock<IHotelRepository>();
        var hotelService = _autoMocker.CreateInstance<HotelService>();

        var hotel = _fixture.Create<Hotel>();
        hotel.LocalAirports = new List<string>{"AGP"};
        hotel.ArrivalDate = "2023-07-01";
        hotel.Nights = 7;

    var expectedHotels = new List<Hotel> { hotel };
        

        hotelRepoMock.Setup(h => h.GetHotels()).Returns(expectedHotels);
        
        // Act

        var hotels = hotelService.GetFilteredHotels("AGP", "2023-07-01", 7);
        
        // Assert
        hotels.Should().BeEquivalentTo(expectedHotels);


    }
}