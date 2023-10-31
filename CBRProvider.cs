using System.Text;
using System.Xml.Serialization;
using CurrencyRatesLoader.Data;

public class CBRProvider // выгружает данные из ЦБ сервиса и десериализирует в объект приложения
{
    private HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("https://cbr.ru/scripts/") };
    private XmlSerializer serializer;

    public string Check(int num) 
    {
        if(num < 10)
        {
            return "0" + num;
        }
        else
        {
            return num.ToString();
        }
    }
    public CBRProvider()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        serializer = new XmlSerializer(typeof(ValCurs));
    }

    public async Task<List<ValCurs>> GetData()
    {
        List<ValCurs> valCurs = new List<ValCurs>();
        var now = DateTime.Now;
        var startDate = now.AddMonths(-1);
        while (startDate <= now)
        {
            var response = await httpClient.GetAsync("XML_daily.asp?date_req=" + Check(startDate.Day) + "/" + Check(startDate.Month) + "/" + startDate.Year);
            var res = await response.Content.ReadAsStreamAsync(); 
            valCurs.Add((ValCurs)serializer.Deserialize(res));
            startDate = startDate.AddDays(1);
        }
        return valCurs;
    }
}