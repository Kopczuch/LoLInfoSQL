using System.Net.Http.Json;

namespace LoLInfoSQL.Client.Services.BohaterowieService
{
	public class BohaterowieService : IBohaterowieService
	{
		private readonly HttpClient http;
        public BohaterowieService(HttpClient http)
        {
            this.http = http;
        }
        public List<Bohaterowie> Champions { get; set; } = new List<Bohaterowie>();

        public async Task GetChampions()
        {
            var result = await http.GetFromJsonAsync<List<Bohaterowie>>("api/bohaterowie");
            if (result != null)
                Champions = result;
        }

        public async Task<Bohaterowie> GetSingleChampion(string name)
        {
            var result = await http.GetFromJsonAsync<Bohaterowie>($"api/bohaterowie/{name}");
            if (result != null)
                return result;
            throw new Exception("Champion not found!");
        }
    }
}
