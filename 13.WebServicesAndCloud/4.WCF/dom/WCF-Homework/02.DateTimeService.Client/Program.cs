using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.DateTimeService.Client.DayOfWeekService;

namespace _02.DateTimeService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DayOfWeekServiceClient();
            var dayOfWeek = client.GetDayOfWeekFromDateTime(DateTime.Now);
            Console.WriteLine(dayOfWeek);
        }
    }
}
