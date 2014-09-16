using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DeleteByPrice
{
    using Catalogue;

    class Program
    {
        static void Main(string[] args)
        {
            var catalogue = new Catalogue("..//..//..//catalogue.xml");
            catalogue.DeleteByPrice(10);
        }
    }
}
