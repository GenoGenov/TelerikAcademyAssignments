using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CalculateWorkDays
{
    class WorkDays
    {
        private static DateTime now = DateTime.Now;
        private static List<DateTime> holidays = new List<DateTime>() { new DateTime(1111, 1, 1), new DateTime(1111, 3, 3), new DateTime(1111, 5, 1), new DateTime(111, 5, 6), new DateTime(111, 5, 24), new DateTime(1111, 9, 6), new DateTime(1111, 9, 22), new DateTime(1111, 11, 1), new DateTime(1111, 12, 24), new DateTime(1111, 12, 25), new DateTime(1111, 12, 26), new DateTime(1111, 12, 31)};
        
        private DateTime date;

        public WorkDays(DateTime d)
        {
            this.date = d;
        }

        private void PrintNumberOfWorkDays(int n,WorkDays w)
        {
            Console.WriteLine("The number of workdays from today till {0} is {1}",w.date,n);
        }
        public void GetWorkDays()
        {
            int result = 0;

            while (now.Year!=date.Year || now.Month!=date.Month || now.Day!=date.Day)
            {
                if (!now.DayOfWeek.ToString().Equals("Saturday") && !now.DayOfWeek.ToString().Equals("Sunday"))
                {
                    bool flag = true;
                    for (int i = 0; i < holidays.Count; i++)
                    {
                        if (holidays[i].Month == now.Month && holidays[i].Day == now.Day)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        result++;
                    }
                }
                now=now.AddDays(1);
            }

            PrintNumberOfWorkDays(result, this);
        }
    }
}
