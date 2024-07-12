using OnTheBeachTechTest;

namespace OnTheBeachTechnicalTest.Implementation.Repository

{
public class HotelRepository : IHotelRepository
{
    private readonly string _JsonPath;

    public HotelRepository(string jsonPath)
    {
        _JsonPath = jsonPath;
    }

    public List<Hotel> GetHotels()
    {
        throw new NotImplementedException();
    }
}
}
