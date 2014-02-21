using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class Worker : Student
    {
        #region Fields

        private int weekSalary;
        private int workHoursPerDay;

        #endregion

        #region Constructors

        public Worker(string first, string last, int salary, int workHours) : base(first, last)
        {
            this.WeekSalary = salary;
            this.WorkHoursPerDay = workHours;
        }

        #endregion

        #region Properties

        public int WorkHoursPerDay
        {
            get { return workHoursPerDay; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Working hours must be 1 or more");
                }
                workHoursPerDay = value;
            }
        }

        public int WeekSalary
        {
            get { return weekSalary; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("salary must be bigger than 0");
                }
                weekSalary = value;
            }
        }

        #endregion

        #region Methods

        public decimal MoneyPerHour()
        {
            return (this.WeekSalary/5.0m)/(decimal) WorkHoursPerDay;
        }

        #endregion
    }
}