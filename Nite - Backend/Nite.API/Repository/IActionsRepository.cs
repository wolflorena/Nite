using Nite.API.Repository.Entities;

namespace Nite.API.Repository
{
    public interface IActionsRepository
    {
        IEnumerable<Favorites> GetAllFavorites(int userId);
        IEnumerable<Add> GetAllAddedShows(int userId);
        IEnumerable<Watch> GetAllWatchedEpisodes(int userId);


        void AddFavorite(Favorites favorite);
        void AddAddedShow(Add added);
        void AddWatchedEpisode(Watch watched);
        bool ShowExistInAdded(int? userId, int? showId);


        Favorites? GetFavorite(int? userId, int? showId);
        Add? GetAddedShow(int? userId, int? showId);
        Watch? GetWatchedEpisode(int? userId, int? showId, int? seasonId, int? episodeId);
        void DeleteFavorite(Favorites favorite);
        void DeleteAddedShow(Add added);
        void DeleteWatchedEpisode(Watch watched);



        bool UserExist(int userId);
        bool ShowExist(int showId);
        bool SeasonExist(int seasonId);
        bool EpisodeExist(int episodeId);

        bool Save();
    }
}
