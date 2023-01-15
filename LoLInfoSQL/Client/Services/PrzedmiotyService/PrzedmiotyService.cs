using System.Net.Http.Json;

namespace LoLInfoSQL.Client.Services.PrzedmiotyService
{
    public class PrzedmiotyService : IPrzedmiotyService
    {
        private readonly HttpClient http;
        public PrzedmiotyService(HttpClient http)
        {
            this.http = http;
        }
        public List<Przedmioty> Items { get; set; } = new List<Przedmioty>();

        public async Task GetItems()
        {
            var result = await http.GetFromJsonAsync<List<Przedmioty>>("api/przedmioty");
            if (result != null)
                Items = result;
        }

        public async Task<Przedmioty> GetSingleItem(string name)
        {
            var result = await http.GetFromJsonAsync<Przedmioty>($"api/przedmioty/{name}");
            if (result != null)
                return result;
            throw new Exception("Item not found!");
        }
    }
}
