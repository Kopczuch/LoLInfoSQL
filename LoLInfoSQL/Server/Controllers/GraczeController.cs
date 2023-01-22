using LoLInfoSQL.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoLInfoSQL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraczeController : ControllerBase
    {
        private readonly lolinfoContext context;

        public GraczeController(lolinfoContext context)
        {
            this.context = context;
        }

        [HttpGet("{nick}")]
        public async Task<ActionResult<Gracze>> GetPlayer(string nick)
        {
            var player = context.Graczes
                .Include(p => p.GryIdMeczus.OrderByDescending(p=>p.IdMeczu))
                .FirstOrDefault(h => h.Nick == nick);
            return Ok(player);
        }

        private async Task<List<Gracze>> GetDbPlayers()
        {
            return await context.Graczes
                .Include(p => p.GryIdMeczus.OrderByDescending(p => p.IdMeczu))
                .ToListAsync();

        }

        [HttpPut("{nick}")]
        public async Task<ActionResult<List<Gracze>>> UpdatePlayer(Gracze player, string nick)
        {
            var dbPlayer = await context.Graczes
                .Include(p => p.GryIdMeczus.OrderByDescending(p => p.IdMeczu))
                .FirstOrDefaultAsync(c => c.Nick == nick);
            if (dbPlayer == null)
                return NotFound("Nie znaleziono gracza.");

            //dbPlayer.Nick = player.Nick;
            dbPlayer.Dywizja = player.Dywizja;
            dbPlayer.Poziom = player.Poziom;
            dbPlayer.UlubionyBohater = player.UlubionyBohater;

            await context.SaveChangesAsync();

            return Ok(await GetDbPlayers());

        }
    }
}
