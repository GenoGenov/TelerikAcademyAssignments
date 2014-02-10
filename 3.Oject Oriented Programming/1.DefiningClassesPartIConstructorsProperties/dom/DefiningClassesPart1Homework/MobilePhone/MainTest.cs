using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone.Enums;

namespace MobilePhone
{
    internal class MainTest
    {
        private static void Main(string[] args)
        {
            try
            {
                GsmTest.Test();
                GsmCallHistoryTest.Test();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}