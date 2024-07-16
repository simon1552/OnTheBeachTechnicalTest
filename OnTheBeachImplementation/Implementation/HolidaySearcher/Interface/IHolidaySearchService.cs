using OnTheBeachTechnicalTest.Implementation.Models;
using OnTheBeachTechTest;

namespace OnTheBeachTechnicalTest.Implementation.HolidaySearcher;

public interface IHolidaySearchService
{
    List<HolidaySearchResult> SearchHolidays(HolidaySearch searchCriteria);
}
