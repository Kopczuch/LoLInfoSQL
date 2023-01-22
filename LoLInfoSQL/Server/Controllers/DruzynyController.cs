using LoLInfoSQL.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Utilities.IO;

namespace LoLInfoSQL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DruzynyController : ControllerBase
    {
        private readonly lolinfoContext context;

        public DruzynyController(lolinfoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Druzyny>>> GetTeams()
        {
            var teams = await context.Druzynies.ToListAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Druzyny>> GetSingleTeam(string id)
        {
            var team = context.Druzynies
                .Include(p => p.Turniejes)
                .FirstOrDefault(h => h.IdDruzyny == id);

            if (team == null)
            {
                return NotFound("Sorry! No team with that id.");
            }
            return Ok(team);
        }


        [HttpGet("{id}/sklad")]
        public async Task<ActionResult<GraczeZawodowi>> GetMembers(string id)
        {
            var members = await context.GraczeZawodowis.FromSqlRaw($"call getPlayersByTeam('{id}')").ToListAsync();
            if (members == null)
            {
                return NotFound("Sorry! No members found.");
            }
            return Ok(members);
        }

        [HttpGet("Search/{searchText}")]
        public async Task<ActionResult<List<Druzyny>>> SearchTeam(string searchText)
        {
            var team = context.Druzynies
                .Where(p => p.Nazwa.Contains(searchText) ||
                        p.IdDruzyny.Contains(searchText));
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<List<Druzyny>>> CreateTeam(Druzyny team)
        {
            context.Druzynies.Add(team);
            await context.SaveChangesAsync();
            return Ok(await GetDbTeams());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Druzyny>>> UpdateTeam(Druzyny team, string id)
        {
            var dbTeam = await context.Druzynies.FirstOrDefaultAsync(p => p.IdDruzyny == id);

            if (dbTeam == null)
                return NotFound("Nie znaleziono drużyny o podanym id.");

            dbTeam.IdDruzyny = team.IdDruzyny;
            dbTeam.Nazwa = team.Nazwa;
            dbTeam.Opis = team.Opis;
            dbTeam.Liga = team.Liga;
            dbTeam.Logo = team.Logo;
            dbTeam.ZdjecieZawodnikow = team.ZdjecieZawodnikow;

            await context.SaveChangesAsync();

            return Ok(await GetDbTeams());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Druzyny>>> DeleteTeam(string id)
        {
            var dbTeam = await context.Druzynies.FirstOrDefaultAsync(p => p.IdDruzyny == id);
            if (dbTeam == null)
                return NotFound("Nie znaleziono drużyny o podanym id.");

            context.Druzynies.Remove(dbTeam);
            await context.SaveChangesAsync();

            return Ok(await GetDbTeams());
        }


        private async Task<List<Druzyny>> GetDbTeams()
        {
            return await context.Druzynies.ToListAsync();
        }
    }
}
