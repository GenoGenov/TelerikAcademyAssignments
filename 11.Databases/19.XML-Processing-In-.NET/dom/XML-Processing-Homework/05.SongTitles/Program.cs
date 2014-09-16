using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SongTitles
{
    using Catalogue;

    class Program
    {
        static void Main(string[] args)
        {
            var catalogue = new Catalogue("..//..//..//catalogue.xml");
            Console.WriteLine(string.Join(", ", catalogue.GetAllSongTitles()));

        }
    }
}
