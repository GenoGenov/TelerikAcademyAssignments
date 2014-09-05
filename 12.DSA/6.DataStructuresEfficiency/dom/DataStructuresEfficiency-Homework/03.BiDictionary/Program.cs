using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BiDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            BiDictionary<string, string, string> dictionary = new BiDictionary<string, string, string>();
            dictionary.Add("Ivko", "mivko", "Ivko Mivko");
            dictionary.Add("Telerik", "Academy", "Telerik aka");
            dictionary.Add("Telerik", "asdf", "Peter Petrov");
            dictionary.Add("asdf", "Academy", "Dancho Danchev");


            var fromSofia = dictionary.FindByFistKey("Ivko");
            foreach (var item in fromSofia)
            {
                Console.WriteLine(item);
            }

            var manGender = dictionary.FindBySecondKey("asdf");
            foreach (var item in manGender)
            {
                Console.WriteLine(item);
            }

            var manFromPlovdiv = dictionary.FindByBothKeys("Telerik", "Academy");
            foreach (var item in manFromPlovdiv)
            {
                Console.WriteLine(item);
            }
        }
    }
}
