using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CurrencyRatesLoader.Data
{
    public class Valute
    {
        [XmlAttribute]
        public string ID{get;set;}
        public ushort NumCode {get;set;}
        public string CharCode {get;set;}
        public uint Nominal {get;set;}
        public string Name {get;set;}
        public string Value {get;set;}
        public string VunitRate {get;set;}
    }
}