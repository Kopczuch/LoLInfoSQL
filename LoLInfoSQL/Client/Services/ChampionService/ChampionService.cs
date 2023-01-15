using System.Net.Http.Json;

namespace LoLInfoSQL.Client.Services.ChampionService
{
	public class ChampionService : IChampionService
	{
		private readonly HttpClient http;

		public ChampionService(HttpClient http)
		{
			this.http = http;
		}
		public List<Champion> Champions { get; set; } = new List<Champion>();
		public List<Role> Roles { get; set; } = new List<Role>();

		public async Task GetChampions()
		{
			var result = await http.GetFromJsonAsync<List<Champion>>("api/champion");
			if (result != null)
				Champions = result;
		}

		public async Task GetRoles()
		{
            var result = await http.GetFromJsonAsync<List<Role>>("api/champion/roles");
            if (result != null)
                Roles = result;
        }

        public async Task<Champion> GetSingleChampion(string name)
		{
            var result = await http.GetFromJsonAsync<Champion>($"api/champion/{name}");
			if (result != null)
				return result;
			throw new Exception("Champion not found!");
        }
	}
}
