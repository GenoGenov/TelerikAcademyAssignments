using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ExtractArtistsXPath
{
    using Catalogue;

    class Program
    {
        static void Main(string[] args)
        {
            var catalogue = new Catalogue("..//..//..//catalogue.xml");
            var artists = catalogue.ExtractArtistsAlbumsXPath();

            foreach (var artist in artists)
            {
                Console.WriteLine(artist.Key + " -> " + artist.Value + " songs");
            }
        }
    }
}
