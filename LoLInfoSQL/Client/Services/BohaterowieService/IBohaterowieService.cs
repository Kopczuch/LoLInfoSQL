namespace LoLInfoSQL.Client.Services.BohaterowieService
{
	public interface IBohaterowieService
	{
        List<Bohaterowie> Champions { get; set; }

        Task GetChampions();
        Task<Bohaterowie> GetSingleChampion(string name);
    }
}
