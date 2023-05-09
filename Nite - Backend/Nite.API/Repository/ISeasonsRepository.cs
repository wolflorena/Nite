using Nite.API.Repository.Entities;

namespace Nite.API.Repository
{
    public interface ISeasonsRepository
    {
        IEnumerable<Season> GetAllSeasons();
        IEnumerable<Season> GetSeasons(int showId);
        Season? GetSeason(int? showId, int? seasonId);
        TVShow? GetTVShow(int showId);
        void AddSeason(int showId, Season season);
        void DeleteSeason(Season season);
        bool TVShowExist(int showId);
        bool Save();
    }
}
