namespace CurrencyRatesLoader
{
    public class Program
    {
        private static Timer timer;
        public static async void FromCBRToDb(object o)
        {
            var cbrProvider = new CBRProvider();
            var valCurs = await cbrProvider.GetData();
            var dbProvider = new DbProvider();
            await dbProvider.LoadToDb(valCurs);
        }
        public static void Main()
        {
            TimerCallback callback = new TimerCallback(FromCBRToDb);
            timer = new Timer(FromCBRToDb, null, 0, 600000);
            for (; ; )
            {
                Thread.Sleep(1000);
            }
        }



    }
}

