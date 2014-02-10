using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Call
    {
        #region Fields

        private DateTime dateTime;
        private string dialedPhone;
        private uint duration;

        public Call(DateTime dateTime)
        {
            this.DateTime = dateTime;
        }

        #endregion

        #region Properties

        public DateTime Date
        {
            get { return this.DateTime.Date; }
        }

        public string Time
        {
            get { return this.DateTime.ToString("HH:mm:ss"); }
        }

        public DateTime DateTime
        {
            get { return dateTime; }
            private set { dateTime = value; }
        }

        public string DialedPhone
        {
            get { return dialedPhone; }
            private set
            {
                if (value.Length < 6)
                {
                    throw new ArgumentOutOfRangeException("The caller ID must be longer or equal to 6 digits");
                }
                dialedPhone = value;
            }
        }

        public uint Duration
        {
            get { return duration; }
            private set { duration = value; }
        }

        #endregion

        #region Constructors

        public Call(DateTime dateTime, string dialedPhone, uint duration)
        {
            this.DateTime = dateTime;
            this.DialedPhone = dialedPhone;
            this.Duration = duration;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return String.Format("\nCall Info:\nDate: {0:yyyy MMMM dd}\nTime: {1}\nDuration: {2}\nDialed Phone: {3}",
                this.Date,
                this.Time, this.Duration, this.DialedPhone);
        }

        #endregion
    }
}