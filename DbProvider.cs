using CurrencyRatesLoader.Data;
using Microsoft.EntityFrameworkCore;

public class DbProvider
{
    private AppContext db;
    public DbProvider()
    {
        db = new AppContext();
    }

    public async Task LoadToDb(List<ValCurs> valCursList)
    {
        foreach (var valCurs in valCursList)
        {
            foreach (var val in valCurs.Valute)
            {
                var newValute = new ValuteDB() { Id = val.ID, CharCode = val.CharCode, Name = val.Name, NumCode = val.NumCode };
                if (!db.Valutes.Any(x => x.Id == newValute.Id))
                {
                    db.Valutes.Add(newValute);
                }
                await db.SaveChangesAsync();
                var datevalues = db.Valutes.Include(x => x.DateValues);
                if (!datevalues.Where(x => x.Id == newValute.Id).FirstOrDefault().DateValues.Any(x => x.Date == Convert.ToDateTime(valCurs.Date).ToUniversalTime()))
                {
                    db.Valutes.Where(x => x.Id == newValute.Id).FirstOrDefault().DateValues.Add(new DateValue()
                    {
                        Date = Convert.ToDateTime(valCurs.Date).ToUniversalTime(),
                        Nominal = val.Nominal,
                        Value = Convert.ToDouble(val.Value),
                        VunitRate = Convert.ToDouble(val.VunitRate)
                    });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
