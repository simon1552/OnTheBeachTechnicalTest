using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace OnTheBeachTechnicalTest.Implementation.Repository;

public class FlightRepository : IFlightRepository
{
    public List<Flight> GetFlights()
    {
        // Load from JSON file
        var jsonData = File.ReadAllText("../net8.0/Implementation/Json/Flights.json");
        return JsonConvert.DeserializeObject<List<Flight>>(jsonData);
    }
}