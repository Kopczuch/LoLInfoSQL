using LoLInfoSQL.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var proplayer = context.GraczeZawodowis.FirstOrDefault(h => h.Nick == nick);

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
    }
}
