using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotations
{
    class quotes
    {
        static void Main(string[] args)
        {
            string quoted= @"The ""use"" of quotations causes difficulties.";
            string escaped = "The \"use\" of quotations causes difficulties.";

            Console.WriteLine(quoted);
            Console.WriteLine(escaped);
        }
    }
}
