using OnTheBeachTechnicalTest.Implementation.HolidaySearcher;

namespace OnTheBeachTechnicalTest.Implementation.Service;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _flightRepository;

    public FlightService(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }
    public List<Flight> GetFilteredFlights(string departingFrom, string travelingTo, string departureDate)
    {
        return _flightRepository.GetFlights()
            .Where(f => (f.From == departingFrom) && f.To == travelingTo &&
                        f.DepartureDate == departureDate).ToList();
    }
}