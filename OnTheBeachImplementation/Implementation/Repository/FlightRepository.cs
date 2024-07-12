
namespace OnTheBeachTechnicalTest

{
public class FlightRepository : IFlightRepository
{
    private readonly string _JsonPath;

    public FlightRepository(string jsonPath)
    {
        _JsonPath = jsonPath;
    }

    public List<Flight> GetFlights()
        {
            throw new NotImplementedException();
        }
}
}
