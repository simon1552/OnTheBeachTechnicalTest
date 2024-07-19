using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using OnTheBeachTechnicalTest;
using OnTheBeachTechnicalTest.Implementation.Repository;
using OnTheBeachTechnicalTest.Implementation.Service;

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

        var validJsonFlight = _fixture.Build<Flight>()
            .With(f => f.From, "MAN")
            .With(f => f.To, "PMI")
            .With(f => f.DepartureDate, "2023-06-15")
            .Create();
        
        
        var randomFlights = _fixture.CreateMany<Flight>(5).ToList();
        randomFlights.ForEach(f =>
        {
            f.From = "BLN";
            f.To = "AMS";
            f.DepartureDate = "2022-01-01";
        });

        var allFlights = new List<Flight>(randomFlights) { validJsonFlight };
        
        flightRepository.Setup(f => f.GetFlights()).Returns(allFlights);

        // Act
        var flights = flightService.GetFilteredFlights("MAN", "PMI", "2023-06-15");
        
        // Assert
        flights.Should().Contain(f => f.From == "MAN" && f.To == "PMI" && f.DepartureDate == "2023-06-15").Which
            .Should().BeEquivalentTo(validJsonFlight);

    }
}