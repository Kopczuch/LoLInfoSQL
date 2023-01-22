﻿namespace LoLInfoSQL.Client.Services.GraczeZawodowiService
{
    public interface IGraczeZawodowiService
    {
        List<GraczeZawodowi> ProPlayers { get; set; }

        Task GetProPlayers();
        Task<GraczeZawodowi> GetSingleProPlayer(string nick);

        Task SearchProPlayer(string searchText);
        Task CreateProPlayer(GraczeZawodowi proplayer);
        Task UpdateProPlayer(GraczeZawodowi proplayer);
        Task DeleteProPlayer(string nick);
    }
}
