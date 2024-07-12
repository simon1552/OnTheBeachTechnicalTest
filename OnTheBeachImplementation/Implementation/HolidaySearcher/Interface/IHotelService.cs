using OnTheBeachTechTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeachTechnicalTest.Implementation.HolidaySearcher
{
    public interface IHotelService
    {
        List<Hotel> GetFilteredHotels(string travelingTo, string arrivalDate, int duration);
    }
}
