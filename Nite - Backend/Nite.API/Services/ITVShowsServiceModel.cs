using Nite.API.Data.Models;

namespace Nite.API.Services
{
    public interface ITVShowsServiceModel
    {
        IEnumerable<TVShowDTO> GetTVShowsService();
        TVShowDTO GetTVShowService(int id);
        TVShowDTO AddTVShowService(TVShowCreationDTO show);



        void UpdateWithPutTVShow(int showId, TVShowUpdateDTO show);
        TVShowUpdateDTO UpdateWithPatchTVShow(int id);
        void UpdateTVShowFinishService(int id, TVShowUpdateDTO showToPatch);


        void DeleteTVShowService(int id);


        bool TVShowExistsService(int showId);
        bool SaveService();
    }
}
