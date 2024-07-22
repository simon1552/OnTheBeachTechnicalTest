using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using Newtonsoft.Json;
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
        
        var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../net8.0/Implementation/Json/Hotels.json");
        List<Hotel> allHotels;
        using (var streamReader = new StreamReader(jsonFilePath))
        {
            var jsonData = streamReader.ReadToEnd();
            allHotels = JsonConvert.DeserializeObject<List<Hotel>>(jsonData);
        }

        hotelRepoMock.Setup(h => h.GetHotels()).Returns(allHotels);
        
        //Act
        var hotels = hotelService.GetFilteredHotels("PMI", "2023-06-15", 10);

        // Assert
        
        var expectedJsonHotels = allHotels.FindAll(h => h.LocalAirports.Contains("PMI") && h.ArrivalDate == "2023-06-15" && h.Nights == 10);
        hotels.Should().BeEquivalentTo(expectedJsonHotels);

    }

}