using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoLInfoSQL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionController : ControllerBase
    {
        public static List<Role> roles = new List<Role>
        {
            new Role { Id = 1, Name = "Assassin"},
            new Role { Id = 2, Name = "Fighter"},
            new Role { Id = 3, Name = "Mage"},
            new Role { Id = 4, Name = "Marksman"},
            new Role { Id = 5, Name = "Support"},
            new Role { Id = 6, Name = "Tank"}
        };


        public static List<Champion> champions = new List<Champion>
        {
            new Champion
            {
                Id = 1,
                Name = "Aatrox",
                Title = "The Darkin Blade",
                Description = "Once honored defenders of Shurima " +
                "against the Void, Aatrox and his brethren " +
                "would eventually become an even greater threat to Runeterra, " +
                "and were defeated only by cunning mortal sorcery. " +
                "But after centuries of imprisonment, Aatrox was the first to find freedom once more, " +
                "corrupting and transforming those foolish enough to try and wield the magical weapon" +
                " that contained his essence. Now, with stolen flesh, he walks Runeterra in a brutal " +
                "approximation of his previous form, seeking an apocalyptic and long overdue vengeance.",
                Role = roles[1],
                RoleId = 2,
                Attack = 60,
                Defense = 70,
                Magic = 0,
                Difficulty = 2
            },

            new Champion
            {
                Id = 2,
                Name = "Ahri",
                Title = "The Nine-tailed Fox",
                Description = "Innately connected to the latent power of Runeterra, Ahri is a vastaya " +
                "who can reshape magic into orbs of raw energy. She revels in toying with her prey by " +
                "manipulating their emotions before devouring their life essence. Despite her predatory nature, " +
                "Ahri retains a sense of empathy as she receives flashes of memory from each soul she consumes.",
                Role = roles[2],
                RoleId = 3,
                Attack = 53,
                Defense = 48,
                Magic = 30,
                Difficulty = 2
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Champion>>> GetChampions()
        {
            return Ok(champions);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Champion>> GetSingleChampion(string name)
        {
            var champion = champions.FirstOrDefault(h => h.Name == name);
            if (champion == null)
            {
                return NotFound("No champion with that name.");
            }
            return champion;
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            return Ok(roles);
        }

    }
}
