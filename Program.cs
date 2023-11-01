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
           
            while(true) // Проверяет начало нового дня каждую минуту и если он наступил отправляет запрос. Лучше было бы определить, что данные обновились на новый день и в этом момент выгружать.
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

