using Newtonsoft.Json;
using OnTheBeachTechTest;

namespace OnTheBeachTechnicalTest.Implementation.Repository;

public class HotelRepository : IHotelRepository
{
    public List<Hotel> GetHotels()
    {
        // Load from JSON file
        var jsonData = File.ReadAllText("/Users/simosiu/Downloads/WIP/OnTheBeachTechnicalTest/OnTheBeachImplementation/Implementation/Json/Hotels.json");
        return JsonConvert.DeserializeObject<List<Hotel>>(jsonData);
    }
}