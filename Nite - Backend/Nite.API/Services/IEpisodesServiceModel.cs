using Nite.API.Data.Models;

namespace Nite.API.Services
{
    public interface IEpisodesServiceModel
    {
        IEnumerable<EpisodeDTO> GetAllEpisodesService();
        bool TVShowExistService(int showId);
        bool SeasonExistService(int showId, int seasonId);
        IEnumerable<EpisodeDTO> GetEpisodesService(int showId, int seasonId);
        EpisodeDTO? GetEpisodeService(int? showId, int? seasonId, int? episodeId);
        EpisodeDTO AddEpisodeService(int showId, int seasonId, EpisodeCreationDTO episode);
        void UpdateWithPutEpisode(int showId, int seasonId, int id, EpisodeUpdateDTO episode);
        void DeleteEpisodeService(int showId, int seasonId, int id);
        bool SaveService();
    }
}
