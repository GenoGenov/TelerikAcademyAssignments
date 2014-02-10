using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MobilePhone.Enums;

namespace MobilePhone
{
    public class Gsm
    {
        #region Fields

        private static readonly Gsm iPhone4S = new Gsm("4S", "Apple Inc", 399.99m, "Pencho Penchev",
            new Battery("Apple", 10, 7, BatteryType.LiIon), new Display(NumberOfColors.Color16M, 4.0));

        private Battery battery;
        private List<Call> callHistoryList;
        private Display display;
        private string owner;
        private string phoneManufacturer;
        private string phoneModel;
        private decimal? price;

        #endregion

        #region Peoperties

        public string PhoneModel
        {
            get { return phoneModel; }
            set { phoneModel = value; }
        }

        public string PhoneManufacturer
        {
            get { return phoneManufacturer; }
            set { phoneManufacturer = value; }
        }

        public decimal? Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be less than zero");
                }
                price = value;
            }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public Battery Battery
        {
            get { return battery; }
            set { battery = value; }
        }

        public Display Display
        {
            get { return display; }
            set { display = value; }
        }

        public static Gsm IPhone4S
        {
            get { return iPhone4S; }
        }

        private Call CallHistoryAdder
        {
            set { callHistoryList.Add(value); }
        }

        #endregion

        #region Constructors

        public Gsm(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
        {
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.PhoneManufacturer = manufacturer;
            this.PhoneModel = model;
            this.Price = price;
            this.callHistoryList = new List<Call>();
        }

        public Gsm(string model, string manufacturer)
            : this(model, manufacturer, null, null, null, null)
        {
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            var phoneInfo = new StringBuilder();

            phoneInfo.AppendLine("**********************Phone info:**************************");
            phoneInfo.AppendLine(string.Format("Owner: {0}", this.Owner));
            phoneInfo.AppendLine(string.Format("Manufacturer: {0}", this.PhoneManufacturer));
            phoneInfo.AppendLine(string.Format("Model: {0}", this.PhoneModel));
            phoneInfo.AppendLine(string.Format("Price: {0}", this.Price));
            phoneInfo.AppendLine(Battery.ToString());
            phoneInfo.AppendLine(Display.ToString());
            phoneInfo.AppendLine("*********************END OF PHONE INFO*********************");

            return phoneInfo.ToString();
        }

        public void AddCall(Call call)
        {
            this.CallHistoryAdder = call;
        }

        public void DeleteCall(Call call)
        {
            this.callHistoryList.Remove(call);
        }

        public void ClearCallList()
        {
            this.callHistoryList.Clear();
        }

        public decimal CalculateTotalPriceCalls(decimal pricePerMinute)
        {
            decimal result = 0m;
            foreach (var call in this.callHistoryList)
            {
                result += (call.Duration/60m)*pricePerMinute;
            }

            return result;

            //Or
            //return this.callHistoryList.Sum(call => (call.Duration/60m)*pricePerMinute);
        }

        public string DisplayCallsinfo()
        {
            var calls = new StringBuilder();
            calls.AppendLine("**********************Calls Info:**************************");
            if (this.callHistoryList.Count == 0)
            {
                return "\nCall History is empty\n";
            }
            foreach (var call in callHistoryList)
            {
                calls.AppendLine(call.ToString());
            }
            calls.AppendLine("*********************END OF CALLS INFO*********************");
            return calls.ToString();
        }

        public void RemoveLongestCall()
        {
            var longest = this.callHistoryList.Max(x => x.Duration);

            this.callHistoryList.RemoveAll(x => x.Duration == longest);
        }

        #endregion
    }
}