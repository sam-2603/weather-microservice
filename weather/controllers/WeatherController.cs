
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace weather.controllers
{
    public class WeatherController
    {
        private static readonly HttpClient http = new();

        // This responds to NATS subject: weather.request
        public async Task<object> weather_request(dynamic payload)
        {
            string city = payload.city.ToString();

            var url = $"https://wttr.in/{city}?format=j2";
            var json = await http.GetStringAsync(url);

            return JsonDocument.Parse(json).RootElement;
        }
    }
}
