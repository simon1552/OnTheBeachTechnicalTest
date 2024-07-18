using System.Collections.Generic;
using System.Linq;
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
        
        
        var flights = _flightRepository.GetFlights();
        
        if (departingFrom == "ANY")
        {
            var londonAirports = new List<string> { "LGW", "LTN" };
            flights = flights.Where(f => londonAirports.Contains(f.From) || f.From == "MAN")
                .ToList();
        }
        else
        {
            flights = flights.Where(f => f.From == departingFrom)
                .ToList();
        }

        flights = flights.Where(f => f.To == travelingTo && f.DepartureDate == departureDate)
            .OrderBy(f => f.Price)
            .ToList();

        return flights.OrderBy(f => f.Price).ToList();
    }
}