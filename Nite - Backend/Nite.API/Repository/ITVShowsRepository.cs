using Nite.API.Repository.Entities;

namespace Nite.API.Repository
{
    public interface ITVShowsRepository
    {
        IEnumerable<TVShow> GetTVShows();
        TVShow? GetTVShow(int showId);
        void AddTVShow(TVShow show);


        void DeleteTVShow(TVShow show);


        bool TVShowExists(int showId);
        bool Save();
    }
}
