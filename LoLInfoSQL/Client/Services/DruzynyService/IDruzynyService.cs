namespace LoLInfoSQL.Client.Services.DruzynyService
{
    public interface IDruzynyService
    {
        List<Druzyny> Teams { get; set; }
        //List<GraczeZawodowi> Members { get; set; }

        Task GetTeams();
        Task<Druzyny> GetSingleTeam(string id);

        Task SearchTeam(string searchText);

        Task<List<GraczeZawodowi>> GetMembers(string id);
    }
}
