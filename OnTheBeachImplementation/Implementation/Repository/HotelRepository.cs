using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OnTheBeachTechTest;

namespace OnTheBeachTechnicalTest.Implementation.Repository;

public class HotelRepository : IHotelRepository
{
    public List<Hotel> GetHotels()
    {
        // Load from JSON file
        var jsonData = File.ReadAllText("../net8.0/Implementation/Json/Hotels.json");
        return JsonConvert.DeserializeObject<List<Hotel>>(jsonData);
    }
}