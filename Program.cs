namespace CurrencyRatesLoader
{
    public class Program
    {
        private static DateTime CurrentDate = DateTime.MinValue;
        public static async void FromCBRToDb()
        {
            var cbrProvider = new CBRProvider();
            var valCurs = await cbrProvider.GetData();
            var dbProvider = new DbProvider();
            await dbProvider.LoadToDb(valCurs);
        }
        public static void Main()
        {
           
            for (; ; )
            {
                if(CurrentDate.Day != DateTime.Now.Day)
                {
                    CurrentDate = DateTime.Now;
                    FromCBRToDb();
                }
                Thread.Sleep(60000);
            }
        }



    }
}

