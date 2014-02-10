using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            decimal tomatoSeeds = decimal.Parse(Console.ReadLine())*0.5m;
            decimal tomatoArea = decimal.Parse(Console.ReadLine());
            decimal cucumberSeeds = decimal.Parse(Console.ReadLine())*0.4m;
            decimal cucumberArea = decimal.Parse(Console.ReadLine());
            decimal potatoSeeds = decimal.Parse(Console.ReadLine())*0.25m;
            decimal potatoArea = decimal.Parse(Console.ReadLine());
            decimal carrotSeeds = decimal.Parse(Console.ReadLine())*0.6m;
            decimal carrotArea = decimal.Parse(Console.ReadLine());
            decimal cabbageSeeds = decimal.Parse(Console.ReadLine())*0.3m;
            decimal cabbageArea = decimal.Parse(Console.ReadLine());
            decimal beansSeeds = decimal.Parse(Console.ReadLine())*0.4m;

            decimal beansArea = 250 - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);
            decimal totalCost = tomatoSeeds + cucumberSeeds + potatoSeeds + carrotSeeds + cabbageSeeds + beansSeeds;
            Console.WriteLine("Total costs: {0:0.00}",totalCost);
            if (beansArea > 0)
            {
                Console.WriteLine("Beans area: {0}",beansArea);
            }
            if (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea > 250)
            {
                Console.WriteLine("Insufficient area");
            }
            else if (beansArea <= 0)
            {
                Console.WriteLine("No area for beans");
            }
        }
    }
}
