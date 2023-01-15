using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LoLInfoSQL.Client.Services.PrzedmiotyService
{
    public interface IPrzedmiotyService
    {
        List<Przedmioty> Items { get; set; }

        Task GetItems();
        Task<Przedmioty> GetSingleItem(string Name);

    }
}
