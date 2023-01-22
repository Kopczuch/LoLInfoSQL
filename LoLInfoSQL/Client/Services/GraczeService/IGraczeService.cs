namespace LoLInfoSQL.Client.Services.GraczeService
{
    public interface IGraczeService
    {
        Task<Gracze> GetPlayer(string nick);

        Task UpdatePlayer(Gracze player);
    }
}
