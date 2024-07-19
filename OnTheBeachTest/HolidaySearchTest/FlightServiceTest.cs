using AutoFixture;
using FluentAssertions;
using Moq;
using Moq.AutoMock;
using OnTheBeachTechnicalTest;
using OnTheBeachTechnicalTest.Implementation.Service;

namespace OnTheBeachTest.HolidaySearchTest;

public class FlightServiceTest
{
    public Fixture _fixture = new Fixture();
    public AutoMocker _autoMocker = new AutoMocker();


    [Test]
    public void GivenFlightRepository_WhenGetFilteredFlightsWithAny_ThenReturnFilteredFlights()
    {
        //arrange
        
        var flightRepo = _autoMocker.GetMock<IFlightRepository>();
        var flightService = _autoMocker.CreateInstance<FlightService>();
        
        var allFlights = _fixture.CreateMany<Flight>(10).ToList();
        
        var matchingFlight = _fixture.Create<Flight>();
        matchingFlight.From = "LGW";
        matchingFlight.To = "PMI";
        matchingFlight.DepartureDate = "2023-06-15";
            
        allFlights.Add(matchingFlight);

        flightRepo.Setup(f => f.GetFlights()).Returns(allFlights);

        // Act
        var flights = flightService.GetFilteredFlights("ANY", "PMI", "2023-06-15");

        // Assert
        flights.Should().ContainSingle();
        flights.First().Should().BeEquivalentTo(matchingFlight);

    } 
    
    [Test]
    public void GivenFlightRepository_WhenGetFilteredFlightsWithAnyLondon_ThenReturnFilteredFlights()
    {
        //arrange
        
        var flightRepo = _autoMocker.GetMock<IFlightRepository>();
        var flightService = _autoMocker.CreateInstance<FlightService>();
        
        var allFlights = _fixture.CreateMany<Flight>(10).ToList();
        
        var matchingFlight = _fixture.Create<Flight>();
        matchingFlight.From = "LTN";
        matchingFlight.To = "PMI";
        matchingFlight.DepartureDate = "2023-06-15";
            
        allFlights.Add(matchingFlight);

        flightRepo.Setup(f => f.GetFlights()).Returns(allFlights);

        // Act
        var flights = flightService.GetFilteredFlights("ANY London", "PMI", "2023-06-15");

        // Assert
        flights.Should().ContainSingle();
        flights.First().Should().BeEquivalentTo(matchingFlight);

    } 
    
    [Test]
    public void GivenFlightRepository_WhenGetFilteredFlightsWithSpecific_ThenReturnFilteredFlights()
    {
        //arrange
        
        var flightRepo = _autoMocker.GetMock<IFlightRepository>();
        var flightService = _autoMocker.CreateInstance<FlightService>();
        
        var allFlights = _fixture.CreateMany<Flight>(10).ToList();
        
        var matchingFlight = _fixture.Create<Flight>();
        matchingFlight.From = "MAN";
        matchingFlight.To = "PMI";
        matchingFlight.DepartureDate = "2023-06-15";
            
        allFlights.Add(matchingFlight);

        flightRepo.Setup(f => f.GetFlights()).Returns(allFlights);

        // Act
        var flights = flightService.GetFilteredFlights("MAN", "PMI", "2023-06-15");

        // Assert
        flights.Should().ContainSingle();
        flights.First().Should().BeEquivalentTo(matchingFlight);

    }
}