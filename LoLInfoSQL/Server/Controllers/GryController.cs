using LoLInfoSQL.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoLInfoSQL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GryController : ControllerBase
    {
        private readonly lolinfoContext context;

        public GryController(lolinfoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Gry>>> GetGames()
        {
            var games = await context.Gries
                .Include(p => p.BohaterowieNazwaNavigation)
                .OrderByDescending(p => p.IdMeczu)
                .ToListAsync();
            return Ok(games);
        }

    }
}
