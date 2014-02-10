using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASCII
{
    class Table
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.OutputEncoding = Encoding.Unicode;
            for (int i = 0; i <= 255; i++)
            {
                Console.WriteLine("{0}: {1}",i,(char)i);
            }
        }
    }
}
