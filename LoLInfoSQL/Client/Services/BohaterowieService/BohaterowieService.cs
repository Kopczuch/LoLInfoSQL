using LoLInfoSQL.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LoLInfoSQL.Client.Services.BohaterowieService
{
	public class BohaterowieService : IBohaterowieService
	{
		private readonly HttpClient http;
        private readonly NavigationManager navigationManager;
        public BohaterowieService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
            this.navigationManager = navigationManager;
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
        public async Task SearchChampion(string searchText)
        {
            var result = await http.GetFromJsonAsync<List<Bohaterowie>>($"api/bohaterowie/Search/{searchText}");
            if (result != null)
                Champions = result;
        }

        private async Task SetChampions(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Bohaterowie>>();
            Champions = response;
            navigationManager.NavigateTo("bohaterowie");
        }

        public async Task CreateChampion(Bohaterowie champion)
        {
            var result = await http.PostAsJsonAsync("api/bohaterowie", champion);
            //await SetChampions(result);
            navigationManager.NavigateTo("bohaterowie");
        }

        public async Task UpdateChampion(Bohaterowie champion)
        {
            var result = await http.PutAsJsonAsync($"api/bohaterowie/{champion.Nazwa}", champion);
            await SetChampions(result);
        }

        public async Task DeleteChampion(string name)
        {
            var result = await http.DeleteAsync($"api/bohaterowie/{name}");
            await SetChampions(result);
        }
    }
}
