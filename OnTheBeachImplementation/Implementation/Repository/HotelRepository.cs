using Newtonsoft.Json;
using OnTheBeachTechTest;

namespace OnTheBeachTechnicalTest.Implementation.Repository;

public class HotelRepository : IHotelRepository
{
    public List<Hotel> GetHotels()
    {
        // Load from JSON file
        var jsonData = File.ReadAllText("OnTheBeachImplementation/Implementation/Json/Hotel.json");
        return JsonConvert.DeserializeObject<List<Hotel>>(jsonData);
    }
}