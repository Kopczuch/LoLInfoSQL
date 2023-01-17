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
                .OrderBy(p => p.Cena)
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
    }
}
