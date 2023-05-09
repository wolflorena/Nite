using Nite.API.Repository.Entities;

namespace Nite.API.Repository
{
    public interface ISeasonsRepository
    {
        IEnumerable<Season> GetAllSeasons();
        IEnumerable<Season> GetSeasons(int showId);
        bool TVShowExist(int showId);
    }
}