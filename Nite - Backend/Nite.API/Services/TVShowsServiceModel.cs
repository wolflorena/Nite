using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository;
using Nite.API.Repository.Entities;

namespace Nite.API.Services
{
    public class TVShowsServiceModel : ITVShowsServiceModel
    {
        private readonly ITVShowsRepository _TVShowsRepository;
        private readonly IMapper _mapper;


        public TVShowsServiceModel(ITVShowsRepository TVShowsRepository, IMapper mapper)
        {
            _TVShowsRepository = TVShowsRepository ?? throw new ArgumentNullException(nameof(TVShowsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<TVShowDTO> GetTVShowsService()
        {
            var result = _TVShowsRepository.GetTVShows();
            return _mapper.Map<IEnumerable<TVShowDTO>>(result);
        }


        public TVShowDTO GetTVShowService(int id)
        {
            var result = _TVShowsRepository.GetTVShow(id);

            return _mapper.Map<TVShowDTO>(result);
        }


        public TVShowDTO AddTVShowService(TVShowCreationDTO show)
        {
            var result = _mapper.Map<TVShow>(show);

            _TVShowsRepository.AddTVShow(result);
            _TVShowsRepository.Save();

            return _mapper.Map<TVShowDTO>(result);
        }

        public void UpdateWithPutTVShow(int showId, TVShowUpdateDTO show)
        {
            var showEntity = _TVShowsRepository.GetTVShow(showId);
            _mapper.Map(show, showEntity);
        }

        public TVShowUpdateDTO UpdateWithPatchTVShow(int id)
        {
            var showEntity = _TVShowsRepository.GetTVShow(id);
            return _mapper.Map<TVShowUpdateDTO>(showEntity);
        }

        public void UpdateTVShowFinishService(int id, TVShowUpdateDTO showToPatch)
        {
            var showEntity = _TVShowsRepository.GetTVShow(id);
            _mapper.Map(showToPatch, showEntity);
        }



        public void DeleteTVShowService(int id)
        {
            var showEntity = _TVShowsRepository.GetTVShow(id);

            _TVShowsRepository.DeleteTVShow(showEntity);

            _TVShowsRepository.Save();
        }



        public bool TVShowExistsService(int showId)
        {
            return _TVShowsRepository.TVShowExists(showId);
        }

        public bool SaveService()
        {
            return _TVShowsRepository.Save();
        }
    }
}
