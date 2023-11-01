using CurrencyRatesLoader.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



public class AppContext: DbContext
    {
        public DbSet<ValuteDB> Valutes {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
            var connectionString = config.GetRequiredSection("ConnectionStrings");
            optionsBuilder.UseNpgsql(connectionString["DefaultConnection"]);
        }
    }