using Nite.API.Repository.Entities;

namespace Nite.API.Repository
{
    public interface IEpisodesRepository
    {
        IEnumerable<Episode> GetAllEpisodes();
        IEnumerable<Episode> GetEpisodes(int showId, int seasonId);
        Episode? GetEpisode(int? showId, int? seasonId, int? episodeId);
        TVShow? GetTVShow(int showId);
        Season? GetSeason(int showId, int seasonId);
        void AddEpisode(int showId, int seasonId, Episode epsiode);
        void DeleteEpisode(Episode episode);
        bool TVShowExist(int showId);
        bool SeasonExist(int showId, int seasonId);
        bool Save();
    }
}
