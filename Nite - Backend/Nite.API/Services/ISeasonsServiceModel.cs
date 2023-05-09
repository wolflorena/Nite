using Nite.API.Data.Models;

namespace Nite.API.Services
{
    public interface ISeasonsServiceModel
    {
        IEnumerable<SeasonDTO> GetAllSeasonsService();
        bool TVShowExistService(int showId);
        IEnumerable<SeasonDTO> GetSeasonsService(int showId);
        SeasonDTO? GetSeasonService(int? showId, int? seasonId);
        SeasonDTO AddSeasonService(int showId, SeasonCreationDTO season);
        void UpdateWithPutSeason(int showId, int id, SeasonUpdateDTO season);
        void DeleteSeasonService(int showId, int id);
        bool SaveService();
    }
}