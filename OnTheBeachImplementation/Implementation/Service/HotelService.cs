using OnTheBeachTechnicalTest.Implementation.HolidaySearcher;
using OnTheBeachTechTest;

namespace OnTheBeachTechnicalTest.Implementation.Service;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }
    
    public List<Hotel> GetFilteredHotels(string travelingTo, string arrivalDate, int duration)
    {
        
        var hotels = _hotelRepository.GetHotels()
            .Where(h => h.LocalAirports.Contains(travelingTo) && h.ArrivalDate == arrivalDate && h.Nights == duration)
            .OrderBy(h => h.PricePerNight)
            .ToList();

        Console.WriteLine($"Filtered Hotels Count: {hotels.Count}");
        hotels.ForEach(h => Console.WriteLine($"Hotel ID: {h.Id}, Name: {h.Name}, Arrival Date: {h.ArrivalDate}, Nights: {h.Nights}, Local Airports: {string.Join(", ", h.LocalAirports)}"));

        return hotels;
    }
}