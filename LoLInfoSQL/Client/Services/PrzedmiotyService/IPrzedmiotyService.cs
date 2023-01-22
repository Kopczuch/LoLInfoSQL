using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LoLInfoSQL.Client.Services.PrzedmiotyService
{
    public interface IPrzedmiotyService
    {
        List<Przedmioty> Items { get; set; }

        Task GetItems();
        Task<Przedmioty> GetSingleItem(string name);

        Task SearchItem(string searchText);

        Task CreateItem(Przedmioty item);
        Task UpdateItem(Przedmioty item);
        Task DeleteItem(string name);
    }
}
