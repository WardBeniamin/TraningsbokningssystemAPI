using System.Net.Http;
using TraningsbokningssystemAPI.Services;

namespace TraningsbokningssystemAPI.Services
{
    public class VäderService : IVäderService
    {
        private readonly HttpClient _http;

        public VäderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> HämtaVäderAsync(DateTime datum)
        {
            // Göteborgs koordinater
            string url = $"https://api.open-meteo.com/v1/forecast?latitude=57.71&longitude=11.97&daily=temperature_2m_max&start_date={datum:yyyy-MM-dd}&end_date={datum:yyyy-MM-dd}&timezone=auto";

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return "Kunde inte hämta väder.";

            var data = await response.Content.ReadAsStringAsync();
            return data;
        }
    }
}
