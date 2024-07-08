using OnTheBeachTechTest;

namespace OnTheBeachTechnicalTest
{
    public class HolidaySearchResult()
    {
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
        public decimal TotalPrice => Flight.Price + Hotel.PricePerNight;
    }
}
