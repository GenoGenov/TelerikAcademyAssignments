using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue
{
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class Catalogue
    {
        private XElement catalogue;

        public Catalogue()
        {
            this.catalogue = new XElement("catalogue");
        }

        public Catalogue(string path)
        {
            this.catalogue = XElement.Load(path);
        }

        public void AddAlbum(string name, string artist, string producer, int year, decimal price)
        {
            var album = new XElement("album");
            album.SetAttributeValue("name",name);
            album.SetAttributeValue("artist",artist);
            album.SetAttributeValue("producer",producer);
            album.SetAttributeValue("year",year);
            album.SetAttributeValue("price",price);
            this.catalogue.Add(album);
        }

        public void AddSong(string albumName, string title, double duration)
        {
            var album = this.catalogue.Descendants("album").First(x => x.Attribute("name").Value == albumName);
            var song = new XElement("song");
            song.Add(new XElement("title",title));
            song.Add(new XElement("duration", duration));
            album.Add(song);
        }

        public void Save(string path)
        {
            this.catalogue.Save(path);
        }

        public Dictionary<string,int> ExtractArtistsAlbums()
        {
            var result = new Dictionary<string, int>();

            XmlDocument doc = new XmlDocument();
            doc.Load("..//..//..//catalogue.xml");
            XmlNode rootNode = doc.DocumentElement;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Attributes["artist"]!=null)
                {
                    if (!result.ContainsKey(node.Attributes["artist"].Value))
                    {
                        result[node.Attributes["artist"].Value] = 0;
                    }
                    result[node.Attributes["artist"].Value]++;
                }
            }
            return result;
        }

        public Dictionary<string, int> ExtractArtistsAlbumsXPath()
        {
            var result = new Dictionary<string, int>();

            XmlDocument doc = new XmlDocument();
            doc.Load("..//..//..//catalogue.xml");

            var artists = doc.SelectNodes("/catalogue/album/@artist");

            foreach (var artist in artists)
            {
                var artistAsNode = artist as XmlNode;
                if (!result.ContainsKey(artistAsNode.Value))
                {
                    result[artistAsNode.Value] = 0;
                }
                result[artistAsNode.Value]++;
            }

            return result;
        }

        public void DeleteByPrice(decimal price)
        {
            var doc = new XmlDocument();
            doc.Load("..//..//..//catalogue.xml");

            var root = doc.DocumentElement;
            var element = root.SelectNodes("/catalogue/album[@price>=" + price + "]").Item(0);
            root.RemoveChild(element);
            doc.Save("..//..//..//catalogue-deleted.xml");
        }

        public IEnumerable<string> GetAllSongTitles()
        {
            var songsTitle = this.catalogue.XPathSelectElements("/album/song/title").Select(x=>x.Value);
            return songsTitle;
        } 
    }
}
