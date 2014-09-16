using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Catalogue
{
    using System.Xml.Linq;

    using global::Catalogue;

    class Program
    {
        static void Main(string[] args)
        {
            var catalogue = new Catalogue();
            catalogue.AddAlbum("dai mu","hisarskiq pop","mitko painera",1998,10m);
            catalogue.AddAlbum("tralala","kichka","painera",2004,0.5m);
            catalogue.AddSong("dai mu","olele",3.55);
            catalogue.AddSong("tralala","nqkva chalga",2.88);

            catalogue.AddAlbum("shat na patkata glavata","slavi","slavi",1997,5m);
            catalogue.AddSong("shat na patkata glavata", "fuck off", 3.55);
            catalogue.AddSong("shat na patkata glavata", "baby", 3.55);
            catalogue.AddAlbum("No Mercy", "slavi", "slavi", 2009, 5m);
            catalogue.AddSong("No Mercy", "ad i rai", 3.55);
            catalogue.AddSong("No Mercy", "bi wish they still", 3.55);
            catalogue.Save("..//..//..//catalogue.xml");

        }

        
    }
}
