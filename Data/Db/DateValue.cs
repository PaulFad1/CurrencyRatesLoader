using System.ComponentModel.DataAnnotations;
using CurrencyRatesLoader.Data;

public class DateValue
{
    [Key]
    public int Id{get;set;}
    public DateTime Date {get;set;}
    public uint Nominal {get;set;}

    public double Value {get;set;}
    public double VunitRate {get;set;}

    public ValuteDB Valute {get;set;}
}