using Newtonsoft.Json;

namespace OnTheBeachTechnicalTest.Implementation.Repository;

public class FlightRepository : IFlightRepository
{
    public List<Flight> GetFlights()
    {
        // Load from JSON file
        var jsonData = File.ReadAllText("/Users/simosiu/Downloads/WIP/OnTheBeachTechnicalTest/OnTheBeachImplementation/Implementation/Json/Flights.json");
        return JsonConvert.DeserializeObject<List<Flight>>(jsonData);
    }
}