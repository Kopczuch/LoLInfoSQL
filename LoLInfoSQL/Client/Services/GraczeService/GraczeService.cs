using System.Net.Http.Json;
using LoLInfoSQL.Client.Pages.Champions;
using Microsoft.AspNetCore.Components;

namespace LoLInfoSQL.Client.Services.GraczeService
{
    public class GraczeService : IGraczeService
    {
        private readonly HttpClient http;
        private readonly NavigationManager navigationManager;
        public GraczeService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
            this.navigationManager = navigationManager;
        }

        public List<Gracze> Players { get; set; } = new List<Gracze>();

        public async Task<Gracze> GetPlayer(string nick)
        {
            var result = await http.GetFromJsonAsync<Gracze>($"api/gracze/{nick}");
            if (result != null)
                return result;
            throw new Exception("Player not found!");
        }

        private async Task SetPlayers(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Gracze>>();
            Players = response;
            //navigationManager.NavigateTo("/");
        }

        public async Task UpdatePlayer(Gracze player)
        {
            var result = await http.PutAsJsonAsync($"api/gracze/edit/{player.Nick}", player);
            await SetPlayers(result);
            navigationManager.NavigateTo($"/gracze/{player.Nick}");
        }
    }
}
