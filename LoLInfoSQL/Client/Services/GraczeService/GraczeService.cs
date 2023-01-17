using System.Net.Http.Json;

namespace LoLInfoSQL.Client.Services.GraczeService
{
    public class GraczeService : IGraczeService
    {
        private readonly HttpClient http;
        public GraczeService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<Gracze> GetPlayer(string nick)
        {
            var result = await http.GetFromJsonAsync<Gracze>($"api/gracze/{nick}");
            if (result != null)
                return result;
            throw new Exception("Player not found!");
        }
    }
}
