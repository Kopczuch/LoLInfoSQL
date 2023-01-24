using LoLInfoSQL.Client.Pages.Champions;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace LoLInfoSQL.Client.Services.PrzedmiotyService
{
    public class PrzedmiotyService : IPrzedmiotyService
    {
        private readonly HttpClient http;
        private readonly NavigationManager navigationManager;
        public PrzedmiotyService(HttpClient http, NavigationManager navigationManager)
        {
            this.http = http;
            this.navigationManager = navigationManager;
        }
        public List<Przedmioty> Items { get; set; } = new List<Przedmioty>();

        //public async Task GetComponents(int id)
        //{
        //    var result = await http.GetFromJsonAsync<List<Przedmioty>>($"api/przedmioty/komponenty/{id}");
        //    if (result != null)
        //        Items = result;
        //}

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


        public async Task SearchItem(string searchText)
        {
            var result = await http.GetFromJsonAsync<List<Przedmioty>>($"api/przedmioty/Search/{searchText}");
            if (result != null)
                Items = result;
        }

        private async Task SetItems(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Przedmioty>>();
            Items = response;
            navigationManager.NavigateTo("przedmioty");
        }

        public async Task CreateItem(Przedmioty item)
        {
            var result = await http.PostAsJsonAsync("api/przedmioty", item);
            //await SetItems(result);
            navigationManager.NavigateTo("przedmioty");
        }

        public async Task UpdateItem(Przedmioty item)
        {
            var result = await http.PutAsJsonAsync($"api/przedmioty/{item.Nazwa}", item);
            await SetItems(result);
        }

        public async Task DeleteItem(string name)
        {
            var result = await http.DeleteAsync($"api/przedmioty/{name}");
            await SetItems(result);
        }
    }
}
