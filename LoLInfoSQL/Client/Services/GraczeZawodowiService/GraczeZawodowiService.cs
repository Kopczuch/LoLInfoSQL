using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace LoLInfoSQL.Client.Services.GraczeZawodowiService
{
    public class GraczeZawodowiService : IGraczeZawodowiService
    {
        private readonly HttpClient http;
        private readonly NavigationManager navigationManager;
        public GraczeZawodowiService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
            this.navigationManager = navigationManager;
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

        private async Task SetProPlayers(HttpResponseMessage result)
        {
            //var response = await result.Content.ReadFromJsonAsync<List<GraczeZawodowi>>();
            ProPlayers = await result.Content.ReadFromJsonAsync<List<GraczeZawodowi>>();
            navigationManager.NavigateTo("graczezawodowi");
        }

        public async Task CreateProPlayer(GraczeZawodowi proplayer)
        {
            var result = await http.PostAsJsonAsync("api/graczezawodowi", proplayer);
            //await SetProPlayers(result);
            navigationManager.NavigateTo("graczezawodowi");
        }

        public async Task UpdateProPlayer(GraczeZawodowi proplayer)
        {
            var result = await http.PutAsJsonAsync($"api/graczezawodowi/{proplayer.Nick}", proplayer);
            await SetProPlayers(result);
            navigationManager.NavigateTo("graczezawodowi");
        }

        public async Task DeleteProPlayer(string nick)
        {
            var result = await http.DeleteAsync($"api/graczezawodowi/{nick}");
            await SetProPlayers(result);
        }
    }
}
