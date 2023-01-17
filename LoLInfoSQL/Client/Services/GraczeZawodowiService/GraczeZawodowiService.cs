using System.Net.Http.Json;

namespace LoLInfoSQL.Client.Services.GraczeZawodowiService
{
    public class GraczeZawodowiService : IGraczeZawodowiService
    {
        private readonly HttpClient http;
        public GraczeZawodowiService(HttpClient http)
        {
            this.http = http;
        }
        public List<GraczeZawodowi> ProPlayers { get; set; } = new List<GraczeZawodowi>();

        public async Task GetProPlayers()
        {
            var result = await http.GetFromJsonAsync<List<GraczeZawodowi>>("api/graczezawodowi");
            if (result != null)
                ProPlayers = result;
        }

        public async Task<GraczeZawodowi> GetSingleProPlayer(string nick)
        {
            var result = await http.GetFromJsonAsync<GraczeZawodowi>($"api/graczezawodowi/{nick}");
            if (result != null)
                return result;
            throw new Exception("Pro player not found!");
        }

        public async Task SearchProPlayer(string searchText)
        {
            var result = await http.GetFromJsonAsync<List<GraczeZawodowi>>($"api/graczezawodowi/Search/{searchText}");
            if (result != null)
                ProPlayers = result;
        }
    }
}
