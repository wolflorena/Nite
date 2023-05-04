using Nite.API.Data.Models;

namespace Nite.API.Services
{
    public interface ISeasonsServiceModel
    {
        IEnumerable<SeasonDTO> GetAllSeasonsService();
        bool TVShowExistService(int showId);
        IEnumerable<SeasonDTO> GetSeasonsService(int showId);
    }
}
