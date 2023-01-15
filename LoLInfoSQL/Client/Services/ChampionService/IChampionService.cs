namespace LoLInfoSQL.Client.Services.ChampionService
{
	public interface IChampionService
	{
		List<Champion> Champions { get; set; }

		List<Role> Roles { get; set; }

		Task GetRoles();
		Task GetChampions();
		Task<Champion> GetSingleChampion(string Name);

	}
}
