using OnTheBeachTechTest;

namespace OnTheBeachTechnicalTest.Implementation.Models;

public class HolidaySearch
{
    public string DepartingFrom { get; set; }
    public string TravelingTo { get; set; }
    public string DepartureDate { get; set; }
    public int Duration { get; set; }
    public List<HolidaySearchResult> Results { get; set; }
    
    public HolidaySearch(string departingFrom, string travelingTo, string departureDate, int duration)
    {
        
    }
}