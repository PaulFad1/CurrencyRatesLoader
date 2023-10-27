using System.Text;
using System.Xml.Serialization;
using CurrencyRatesLoader.Data;

public class CBRProvider
{
    private HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("https://cbr.ru/scripts/") };
    private XmlSerializer serializer;
    public CBRProvider()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        serializer = new XmlSerializer(typeof(ValCurs));
    }

    public async Task<ValCurs> GetData()
    {
        var now = DateTime.Now;
        
        var response = await httpClient.GetAsync("XML_daily.asp?date_req=" + now.Day + "/" + now.Month + "/" + now.Year);
        var res = await response.Content.ReadAsStreamAsync();
        return (ValCurs)serializer.Deserialize(res);
    }
}