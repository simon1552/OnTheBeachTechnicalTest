using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTheBeachTechnicalTest.Implementation.HolidaySearcher
{
    public interface IFlightService
    {
        List<Flight> GetFilteredFlights(string departingFrom, string travelingTo, string departureDate);
    }
}
