using System;
using System.Collections.Generic;
using System.Linq;
using OnTheBeachTechnicalTest.Implementation.Models;
using OnTheBeachTechTest;

namespace OnTheBeachTechnicalTest.Implementation.HolidaySearcher;

public class HolidaySearchService : IHolidaySearchService
{
    private readonly IFlightService _flightService;
    private readonly IHotelService _hotelService;

    public HolidaySearchService(IFlightService flightService, IHotelService hotelService)
    {
        _flightService = flightService;
        _hotelService = hotelService;
    }

    public List<HolidaySearchResult> SearchHolidays(HolidaySearch searchCriteria)
    {
        var flights = _flightService.GetFilteredFlights(searchCriteria.DepartingFrom, searchCriteria.TravelingTo, searchCriteria.DepartureDate);
        var hotels = _hotelService.GetFilteredHotels(searchCriteria.TravelingTo, searchCriteria.DepartureDate, searchCriteria.Duration);
        
        return (from flight in flights
                from hotel in hotels
                select new HolidaySearchResult { Flight = flight, Hotel = hotel })
            .ToList();
    }
}