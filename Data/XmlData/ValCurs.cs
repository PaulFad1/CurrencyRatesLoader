using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CurrencyRatesLoader.Data
{
    public class ValCurs
    {
        [XmlAttribute]
        public string Date{get;set;}
         [XmlAttribute]
        public string name{get;set;}
        [XmlElement("Valute")]
        public Valute[] Valute{get;set;}
    }
}