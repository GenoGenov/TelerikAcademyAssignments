using System;
using System.Globalization;
using System.Linq;
using DatyOfWeekService;

namespace _01.DatyOfWeekService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DayOfWeekService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DayOfWeekService.svc or DayOfWeekService.svc.cs at the Solution Explorer and start debugging.
    public class DayOfWeekService : IDayOfWeekService
    {
        //Test it by selecting the .svc file and then ctrl+f5
        public string GetDayOfWeekBG(DateTime date)
        {
            return CultureInfo.CreateSpecificCulture("bg-BG").DateTimeFormat.GetDayName(date.DayOfWeek);
        }
        public string GetDayOfWeekBG(string date)
        {
            return CultureInfo.CreateSpecificCulture("bg-BG").DateTimeFormat.GetDayName(DateTime.Parse(date).DayOfWeek);
        }
    }
}