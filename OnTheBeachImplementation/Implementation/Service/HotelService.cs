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
        return _hotelRepository.GetHotels()
            .Where(h => h.LocalAirports.Contains(travelingTo) && h.ArrivalDate == arrivalDate && h.Nights == duration)
            .ToList();
    }
}