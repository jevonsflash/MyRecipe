using System;
using System.Xml.Serialization;

namespace MyRecipe.Model
{
    public class KeyWordsMap
    {

        public KeyWordsMap()
        { }
        [XmlElement(ElementName = "id")]
        public int id { get; set; }
        [XmlElement(ElementName = "name")]
        public string name { get; set; }
        [XmlElement(ElementName = "keywords")]
        public string[] keywords { get; set; }
    }
}