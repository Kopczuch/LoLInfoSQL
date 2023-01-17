using System.Net.Http.Json;

namespace LoLInfoSQL.Client.Services.GryService
{
    public class GryService : IGryService
    {
        private readonly HttpClient http;
        public GryService(HttpClient http)
        {
            this.http = http;
        }
        public List<Gry> Games { get; set; } = new List<Gry>();

        public async Task GetGames()
        {
            var result = await http.GetFromJsonAsync<List<Gry>>("api/gry");
            if (result != null)
                Games = result;
        }

    }
}
