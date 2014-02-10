using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    internal class GsmTest
    {
        public static void Test()
        {
            var phones = new List<Gsm>();

            for (int i = 0; i < 5; i++)
            {
                phones.Add(new Gsm(i.ToString(), i.ToString(), i, i.ToString(),
                    new Battery((i + 1).ToString()), new Display()));
            }

            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
            }
        }
    }
}