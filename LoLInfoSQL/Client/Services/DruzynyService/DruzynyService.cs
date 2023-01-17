using System.Net.Http.Json;

namespace LoLInfoSQL.Client.Services.DruzynyService
{
    public class DruzynyService : IDruzynyService
    {
        private readonly HttpClient http;
        public DruzynyService(HttpClient http)
        {
            this.http = http;
        }
        public List<Druzyny> Teams { get; set; } = new List<Druzyny>();
        //public List<GraczeZawodowi> Members { get; set; } = new List<GraczeZawodowi>();

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
    }
}
