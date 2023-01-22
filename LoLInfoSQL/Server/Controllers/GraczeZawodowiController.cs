using LoLInfoSQL.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoLInfoSQL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraczeZawodowiController : ControllerBase
    {
        private readonly lolinfoContext context;

        public GraczeZawodowiController(lolinfoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<GraczeZawodowi>>> GetProPlayers()
        {
            var proplayers = await context.GraczeZawodowis.ToListAsync();
            return Ok(proplayers);
        }

        [HttpGet("{nick}")]
        public async Task<ActionResult<GraczeZawodowi>> GetSingleProPlayer(string nick)
        {
            var proplayer = context.GraczeZawodowis
                .Include(p => p.IdDruzynyNavigation)
                .Include(p => p.GryIdMeczus.OrderByDescending(p => p.IdMeczu))
                .FirstOrDefault(h => h.Nick == nick);

            if (proplayer == null)
            {
                return NotFound("Sorry! No pro player with that nick.");
            }
            return Ok(proplayer);
        }

        [HttpGet("Search/{searchText}")]
        public async Task<ActionResult<List<GraczeZawodowi>>> SearchProPlayers(string searchText)
        {
            var proplayer = context.GraczeZawodowis
                .Where(p => p.Nick.Contains(searchText) ||
                        p.ImieINazwisko.Contains(searchText) ||
                        p.IdDruzyny.Contains(searchText));
            return Ok(proplayer);
        }

        [HttpPost]
        public async Task<ActionResult<List<GraczeZawodowi>>> CreateProPlayer(GraczeZawodowi proplayer)
        {
            proplayer.IdDruzynyNavigation = null;
            context.GraczeZawodowis.Add(proplayer);
            await context.SaveChangesAsync();
            return Ok(await GetDbProPlayers());
        }

        [HttpPut("{nick}")]
        public async Task<ActionResult<List<GraczeZawodowi>>> UpdateProPlayer(GraczeZawodowi proplayer, string nick)
        {
            var dbProPlayer = await context.GraczeZawodowis.FirstOrDefaultAsync(p => p.Nick == nick);

            if (dbProPlayer == null)
                return NotFound("Nie znaleziono gracza zawodowego o podanym nicku.");

            //var proplayerB = context.GraczeZawodowis
            //    .Include(p => p.IdDruzynyNavigation)
            //    .Include(p => p.GryIdMeczus.OrderByDescending(p => p.IdMeczu))
            //    .FirstOrDefault(h => h.Nick == nick);

            dbProPlayer.Nick = proplayer.Nick;
            dbProPlayer.ImieINazwisko = proplayer.ImieINazwisko;
            dbProPlayer.Kraj = proplayer.Kraj;
            dbProPlayer.Rola = proplayer.Rola;
            dbProPlayer.Rezydencja = proplayer.Rezydencja;
            dbProPlayer.Zdjecie = dbProPlayer.Zdjecie;
            dbProPlayer.DataUrodzin = dbProPlayer.DataUrodzin;
            dbProPlayer.IdDruzyny = proplayer.IdDruzyny;
            dbProPlayer.UlubionyBohater = proplayer.UlubionyBohater;
            //if (proplayerB != null)
            //    dbProPlayer.GryIdMeczus = proplayerB.GryIdMeczus;


            await context.SaveChangesAsync();

            return Ok(await GetDbProPlayers());
        }

        [HttpDelete("{nick}")]
        public async Task<ActionResult<List<GraczeZawodowi>>> DeleteProPlayers(string nick)
        {
            var dbProPlayer = await context.GraczeZawodowis
                
                .FirstOrDefaultAsync(p => p.Nick == nick);
            if (dbProPlayer == null)
                return NotFound("Nie znaleziono gracza zawodowego o podanym nicku.");

            context.GraczeZawodowis.Remove(dbProPlayer);
            await context.SaveChangesAsync();

            return Ok(await GetDbProPlayers());
        }


        private async Task<List<GraczeZawodowi>> GetDbProPlayers()
        {
            return await context.GraczeZawodowis.ToListAsync();
        }
    }
}
