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
				.Include(p => p.Gry)
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

		[HttpPost]
		public async Task<ActionResult<List<Bohaterowie>>> CreateChampion(Bohaterowie champion)
		{
			context.Bohaterowies.Add(champion);
			await context.SaveChangesAsync();

			return Ok(champion);
		}

        [HttpPut("{name}")]
        public async Task<ActionResult<List<Bohaterowie>>> UpdateChampion(Bohaterowie champion, string name)
        {
			//champion.Gry.BohaterowieNazwaNavigation = null; 
			var dbChampion = await context.Bohaterowies
				//.Include(p => p.Kontras)
				.Include(p => p.Gry)
				.FirstOrDefaultAsync(c => c.Nazwa == name);
			if (dbChampion == null)
				return NotFound("Nie znaleziono bohatera.");

			dbChampion.Nazwa = champion.Nazwa;
            dbChampion.Tytuł = champion.Tytuł;
            dbChampion.KrotkiOpis = champion.KrotkiOpis;
            dbChampion.Atak = champion.Atak;
            dbChampion.Obrona = champion.Obrona;
            dbChampion.Magia = champion.Magia;
            dbChampion.Trudnosc = champion.Trudnosc;
            dbChampion.Obraz = champion.Obraz;
            dbChampion.Ikona = champion.Ikona;
            dbChampion.Klasa = champion.Klasa;
			//dbChampion.Kontras = champion.Kontras;
			//dbChampion.Gry = champion.Gry;
            //dbChampion.GraczeZawodowis = champion.GraczeZawodowis;
            //dbChampion.Graczes = champion.Graczes;
            //dbChampion.Bohaters = champion.Bohaters;

            await context.SaveChangesAsync();

            return Ok(await GetDbChampions());

        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<List<Bohaterowie>>> DeleteChampion(string name)
        {
            var dbChampion = await context.Bohaterowies
                .FirstOrDefaultAsync(c => c.Nazwa == name);
            if (dbChampion == null)
                return NotFound("Nie znaleziono bohatera.");

			context.Bohaterowies.Remove(dbChampion);

            await context.SaveChangesAsync();

            return Ok(await GetDbChampions());

        }


        private async Task<List<Bohaterowie>> GetDbChampions()
		{
			return await context.Bohaterowies
				//.Include(p => p.Kontras)
				.ToListAsync();

        }
    }
}
