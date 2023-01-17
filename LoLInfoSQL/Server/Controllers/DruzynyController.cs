using LoLInfoSQL.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var team = context.Druzynies.FirstOrDefault(h => h.IdDruzyny == id);

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

    }
}
