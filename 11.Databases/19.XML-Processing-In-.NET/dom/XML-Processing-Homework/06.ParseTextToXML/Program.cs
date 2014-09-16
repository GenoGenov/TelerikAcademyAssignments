using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ParseTextToXML
{
    using System.IO;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var infoParts = new Dictionary<string, string>();
            using (var reader=new StreamReader("..//..//Persons.txt"))
            {
                var line = reader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var parts = line.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToArray();
                    infoParts.Add(parts[0], parts[1]);
                    line = reader.ReadLine();
                }
            }

            var xml = new XElement("person");
            foreach (var infoPart in infoParts)
            {
                xml.Add(new XElement(infoPart.Key,infoPart.Value));
            }
            xml.Save("..//..//..//Person.xml");
        }
    }
}
