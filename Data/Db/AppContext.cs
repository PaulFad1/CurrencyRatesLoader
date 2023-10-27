using CurrencyRatesLoader.Data;
using Microsoft.EntityFrameworkCore;


    public class AppContext: DbContext
    {
        public DbSet<ValuteDB> Valutes {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CurrencyRatesDB;Username=postgres;Password=18-12-97");
        }
    }