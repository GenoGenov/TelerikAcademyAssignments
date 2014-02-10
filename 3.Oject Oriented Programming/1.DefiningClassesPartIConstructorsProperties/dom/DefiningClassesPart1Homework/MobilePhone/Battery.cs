using System;
using MobilePhone.Enums;

namespace MobilePhone
{
    public class Battery
    {
        #region Fields

        private string batteryModel;

        private uint? hoursIdle;

        private uint? hoursTalk;

        private BatteryType? type;

        #endregion

        #region Properties

        public string Model
        {
            get { return batteryModel; }
            set { batteryModel = value; }
        }

        public uint? HoursIdle
        {
            get { return hoursIdle; }
            set { hoursIdle = value; }
        }

        public uint? HoursTalk
        {
            get { return hoursTalk; }
            set { hoursTalk = value; }
        }

        public BatteryType? Type
        {
            get { return type; }
            set { type = value; }
        }

        #endregion

        #region Constructors

        public Battery(string model, uint? hoursIdle, uint? hoursTalk, BatteryType? type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
        }

        public Battery(string model) : this(model, null, null, null)
        {
        }

        public Battery()
        {
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return
                String.Format(
                    "\nBattery Info:\nBattery Type: {0}\nBattery Model: {1}\nHours Idle: {2}\nHours Talk: {3}\n",
                    this.Type,
                    this.Model, this.HoursIdle, this.HoursTalk);
        }

        #endregion
    }
}