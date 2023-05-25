using Nite.API.Data.Models;

namespace Nite.API.Services
{
    public interface IActionsServiceModel
    {
        IEnumerable<FavoritesDTO> GetAllFavoritesService(int userId);
        IEnumerable<AddDTO> GetAllAddedShowsService(int userId);
        IEnumerable<WatchDTO> GetAllWatchedEpisodesService(int userId);


        FavoritesDTO AddFavoriteService(FavoritesCreationDTO favorite);
        AddDTO AddAddedShowService(AddCreationDTO added);
        WatchDTO AddWatchedEpisodeService(WatchCreationDTO watched, int userId, int showId);


        FavoritesDTO? GetFavoriteService(int? userId, int? showId);
        AddDTO? GetAddedShowService(int? userId, int? showId);
        WatchDTO? GetWatchedEpisodeService(int? userId, int? showId, int? seasonId, int? episodeId);
        void DeleteFavoriteService(int userId, int showId);
        void DeleteAddedShowService(int userId, int showId);
        void DeleteWatchedEpisodeService(int userId, int showId, int seasonId, int episodeId);


        bool UserExistService(int userId);
        bool ShowExistService(int showId);
        bool SeasonExistService(int seasonId);
        bool EpisodeExistService(int episodeId);
    }
}
