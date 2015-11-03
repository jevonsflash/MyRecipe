using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Windows.Storage;

namespace MyRecipe.Server
{
    public class MapServer
    {
        public async Task<List<Model.KeyWordsMap>> ReadKeywordsMap(string mapName)
        {
            string path = mapName + ".xml";
            string xmlRootName = mapName + "Maps";
            var storage = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(path);
            string readStr = await FileIO.ReadTextAsync(storage);
            XDocument xd = XDocument.Parse(readStr);
            XmlSerializer ser = new XmlSerializer(typeof(List<Model.KeyWordsMap>), new XmlRootAttribute(xmlRootName));
            XmlReader xr = xd.CreateReader();
            List<Model.KeyWordsMap> obs = (List<Model.KeyWordsMap>)ser.Deserialize(xr);
            return obs;
        }
        public async Task<List<Model.BaseMap>> ReadFilterMap(string mapName)
        {
            string path = mapName + ".xml";
            string xmlRootName = mapName + "Maps";
            var storage = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(path);
            string readStr = await FileIO.ReadTextAsync(storage);

            XDocument xd = XDocument.Parse(readStr);
            XmlSerializer ser = new XmlSerializer(typeof(List<Model.BaseMap>), new XmlRootAttribute(xmlRootName));
            XmlReader xr = xd.CreateReader();
            List<Model.BaseMap> obs = (List<Model.BaseMap>)ser.Deserialize(xr);
            
            return obs;
        }
    }
}
