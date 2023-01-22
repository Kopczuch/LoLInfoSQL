namespace LoLInfoSQL.Client.Services.BohaterowieService
{
	public interface IBohaterowieService
	{
        List<Bohaterowie> Champions { get; set; }

        Task GetChampions();
        Task<Bohaterowie> GetSingleChampion(string name);

        Task SearchChampion(string searchText);

        Task CreateChampion(Bohaterowie champion);
        Task UpdateChampion(Bohaterowie champion);
        Task DeleteChampion(string name);
    }
}
