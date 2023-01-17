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
    }
}
