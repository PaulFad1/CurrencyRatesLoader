using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CurrencyRatesLoader.Data;

public class ValuteDB 
{
    [Key]
    public string Id {get;set;}
    public ushort NumCode {get;set;}
    public string CharCode {get;set;}
    public string Name {get;set;}

    public List<DateValue> DateValues {get;set;} = new List<DateValue>();

}