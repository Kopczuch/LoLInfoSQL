using LoLInfoSQL.Client.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LoLInfoSQL.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BohaterowieController : ControllerBase
	{
		private readonly lolinfoContext context; 

		public BohaterowieController(lolinfoContext context)
		{
			this.context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Bohaterowie>>> GetChampions()
		{
			var champions = await context.Bohaterowies.ToListAsync();
			return Ok(champions);
		}

		[HttpGet("{name}")]
		public async Task<ActionResult<Bohaterowie>> GetSingleChampion(string name)
		{
			var champion = context.Bohaterowies
				.Include(p => p.Kontras)
				.FirstOrDefault(h => h.Nazwa == name);

			if (champion == null)
			{
				return NotFound("Sorry! No champion with that name.");
			}
			return Ok(champion);
		}

        [HttpGet("Search/{searchText}")]
        public async Task<ActionResult<List<Bohaterowie>>> SearchChampions(string searchText)
        {
            var champion = context.Bohaterowies
                .Where(p => p.Nazwa.Contains(searchText));
            return Ok(champion);
        }
    }
}
