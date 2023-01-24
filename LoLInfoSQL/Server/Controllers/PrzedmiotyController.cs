using LoLInfoSQL.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoLInfoSQL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrzedmiotyController : ControllerBase
    {
        private readonly lolinfoContext context;

        public PrzedmiotyController(lolinfoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Przedmioty>>> GetItems()
        {
            var items = await context.Przedmioties
                .OrderBy(p => p.IdPrzed)
                .ThenBy(p => p.Nazwa)
                .ToListAsync();
            return Ok(items);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Przedmioty>> GetSingleItem(string name)
        {
            var item = context.Przedmioties.FirstOrDefault(h => h.Nazwa == name);



            if (item == null)
            {
                return NotFound("Sorry! No item with that name.");
            }
            return Ok(item);
        }

        [HttpGet("/komponenty/{itemid}")]
        public async Task<ActionResult<Przedmioty>> GetComponents(int itemid)
        {
            var components = await context.Przedmioties.FromSqlRaw($"ItemComponents {itemid}").ToListAsync();

            return Ok(components);
        }

        [HttpGet("Search/{searchText}")]
        public async Task<ActionResult<List<Przedmioty>>> SearchItem(string searchText)
        {
            var item = context.Przedmioties
                .Where(p => p.Nazwa.Contains(searchText));
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Przedmioty>>> CreateItem(Przedmioty item)
        {
            context.Przedmioties.Add(item);
            await context.SaveChangesAsync();

            return Ok(await GetDbItems());
        }

        [HttpPut("{name}")]
        public async Task<ActionResult<List<Przedmioty>>> UpdateItem(Przedmioty item, string name)
        {
            var dbItem = await context.Przedmioties
                .FirstOrDefaultAsync(p => p.Nazwa == name);
            if (dbItem == null)
                return NotFound("Nie znaleziono przedmiotu.");

            dbItem.IdPrzed = item.IdPrzed;
            dbItem.Nazwa = item.Nazwa;
            dbItem.Statystyki = item.Statystyki;
            dbItem.Ikona = item.Ikona;
            dbItem.Cena = item.Cena;
            dbItem.WartoscSprzedazy = item.WartoscSprzedazy;

            await context.SaveChangesAsync();

            return Ok(await GetDbItems());

        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<List<Przedmioty>>> DeleteItem(string name)
        {
            var dbItem = await context.Przedmioties
                .FirstOrDefaultAsync(p => p.Nazwa == name);
            if (dbItem == null)
                return NotFound("Nie znaleziono przedmiotu.");

            context.Przedmioties.Remove(dbItem);

            await context.SaveChangesAsync();

            return Ok(await GetDbItems());

        }


        private async Task<List<Przedmioty>> GetDbItems()
        {
            return await context.Przedmioties.ToListAsync();

        }
    }
}
