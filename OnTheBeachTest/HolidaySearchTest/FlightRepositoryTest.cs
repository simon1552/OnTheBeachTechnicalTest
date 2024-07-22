using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using Newtonsoft.Json;
using OnTheBeachTechnicalTest;
using OnTheBeachTechnicalTest.Implementation.Repository;
using OnTheBeachTechnicalTest.Implementation.Service;
using OnTheBeachTechTest;

namespace OnTheBeachTest.HolidaySearchTest;

public class FlightRepositoryTest
{
    public Fixture _fixture = new Fixture();
    public AutoMocker _autoMocker = new AutoMocker();

    [Test]
    public void GivenFlightJson_WhenGetFlights_ThenReturnMatchingFlights()
    {
        
        //Arrange
        
        var flightRepository = _autoMocker.GetMock<IFlightRepository>();
        var flightService = _autoMocker.CreateInstance<FlightService>();
        
        var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../net8.0/Implementation/Json/Flights.json");
        List<Flight> allFlights;
        
        try
        {
            using (var streamReader = new StreamReader(jsonFilePath)) 
            {
                var jsonData = streamReader.ReadToEnd();
                allFlights = JsonConvert.DeserializeObject<List<Flight>>(jsonData);
            }
        }
        catch (FileNotFoundException ex)
        {
            throw new Exception($"Json path file not found: {jsonFilePath}", ex);
        }
        catch (JsonException ex)
        {
            throw new Exception("Failed to deserialize JSON data.", ex);
        }
        
        flightRepository.Setup(f => f.GetFlights()).Returns(allFlights);

        // Act
        var flights = flightService.GetFilteredFlights("ANY", "PMI", "2023-06-15");
        
        // Assert
        
        flights.Should().HaveCount(4);

        var expectedFlights = allFlights.FindAll(f =>
            (f.From == "LGW" || f.From == "LTN" || f.From == "MAN") &&
            f.To == "PMI" &&
            f.DepartureDate == "2023-06-15"
        );

        flights.Should().BeEquivalentTo(expectedFlights);

    }
}