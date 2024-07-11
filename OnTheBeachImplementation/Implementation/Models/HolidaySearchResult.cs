using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using OnTheBeachTechnicalTest;

namespace OnTheBeachTechTest
{
    public class HolidaySearchResult()
    {
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
        public decimal TotalPrice => Flight.Price + (Hotel.PricePerNight * Hotel.Nights);
    }
}