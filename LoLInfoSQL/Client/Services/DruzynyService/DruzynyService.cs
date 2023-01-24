using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LoLInfoSQL.Client.Services.DruzynyService
{
    public class DruzynyService : IDruzynyService
    {
        private readonly HttpClient http;
        private readonly NavigationManager navigationManager;
        public DruzynyService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
            this.navigationManager = navigationManager;
        }
        public List<Druzyny> Teams { get; set; } = new List<Druzyny>();

        public async Task GetTeams()
        {
            var result = await http.GetFromJsonAsync<List<Druzyny>>("api/druzyny");
            if (result != null)
                Teams = result;
        }

        public async Task<Druzyny> GetSingleTeam(string id)
        {
            var result = await http.GetFromJsonAsync<Druzyny>($"api/druzyny/{id}");
            if (result != null)
                return result;
            throw new Exception("Team not found!");
        }

        public async Task<List<GraczeZawodowi>> GetMembers(string id)
        {
            var result = await http.GetFromJsonAsync<List<GraczeZawodowi>>($"api/druzyny/{id}/sklad");
            if (result != null)
                return result;
            throw new Exception("Members not found!");
        }

        public async Task SearchTeam(string searchText)
        {
            var result = await http.GetFromJsonAsync<List<Druzyny>>($"api/druzyny/Search/{searchText}");
            if (result != null)
                Teams = result;
        }

        private async Task SetTeams(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Druzyny>>();
            Teams = response;
            navigationManager.NavigateTo("druzyny");
        }

        public async Task CreateTeam(Druzyny team)
        {
            var result = await http.PostAsJsonAsync("api/druzyny", team);
            //await SetTeams(result);
            navigationManager.NavigateTo("druzyny");
        }

        public async Task UpdateTeam(Druzyny team)
        {
            var result = await http.PutAsJsonAsync($"api/druzyny/{team.IdDruzyny}", team);
            await SetTeams(result);
        }

        public async Task DeleteTeam(string id)
        {
            var result = await http.DeleteAsync($"api/druzyny/{id}");
            await SetTeams(result);
        }
    }
}
