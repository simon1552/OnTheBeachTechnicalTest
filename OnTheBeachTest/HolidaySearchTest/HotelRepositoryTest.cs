using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using OnTheBeachTechnicalTest.Implementation.Service;
using OnTheBeachTechTest;

namespace OnTheBeachTest.HolidaySearchTest;

public class HotelRepositoryTest
{
    public Fixture _fixture = new Fixture();
    public AutoMocker _autoMocker = new AutoMocker();

    [Test]
    public void GivenHotelJson_WhenGetHotels_ThenReturnMatchingHotel()
    {
        var hotelRepoMock = _autoMocker.GetMock<IHotelRepository>();
        var hotelService = _autoMocker.CreateInstance<HotelService>();
        
        var allHotels = _fixture.CreateMany<Hotel>(5).ToList();

        var validJsonHotel = _fixture.Build<Hotel>()
            .With(h => h.LocalAirports, new List<string> {"PMI"})
            .With(f => f.ArrivalDate, "2023-06-15")
            .With(f => f.Nights, 10)
            .Create();
        
        allHotels.Add(validJsonHotel);
        
        var expectedHotels = new List<Hotel> { validJsonHotel };
        
        hotelRepoMock.Setup(h => h.GetHotels()).Returns(allHotels);
        
        //Act
        var hotels = hotelService.GetFilteredHotels("PMI", "2023-06-15", 10);

        // Assert
        hotels.Should().BeEquivalentTo(expectedHotels);

    }

}