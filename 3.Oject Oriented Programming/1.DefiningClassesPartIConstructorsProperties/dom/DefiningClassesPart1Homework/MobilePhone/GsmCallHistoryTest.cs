using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone.Enums;

namespace MobilePhone
{
    internal class GsmCallHistoryTest
    {
        public static void Test()
        {
            Gsm nexus5 = new Gsm
                ("Nexus 5", "Google", 400m, "Goshko", new Battery("Samsing HyperPower", 20, 11, BatteryType.LiIon),
                    new Display(NumberOfColors.Color16M, 4.7));

            nexus5.AddCall(new Call(DateTime.Now, "0882199256", 60));
            nexus5.AddCall(new Call(DateTime.Now, "0882199256", 60));
            nexus5.AddCall(new Call(DateTime.Now, "0882199256", 120));

            Console.WriteLine(nexus5.DisplayCallsinfo());

            Console.WriteLine("Final Price: {0:0.00}",
                nexus5.CalculateTotalPriceCalls(0.37m).ToString("C", CultureInfo.GetCultureInfo("en-US")));

            nexus5.RemoveLongestCall();

            Console.WriteLine("Final Price after removal: {0:0.00}",
                nexus5.CalculateTotalPriceCalls(0.37m).ToString("C", CultureInfo.GetCultureInfo("en-US")));

            nexus5.ClearCallList();

            Console.WriteLine(nexus5.DisplayCallsinfo());
        }
    }
}