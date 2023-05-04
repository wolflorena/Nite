using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository;

namespace Nite.API.Services
{
    public class SeasonsServiceModel : ISeasonsServiceModel
    {
        private readonly ISeasonsRepository _seasonsRepository;
        private readonly IMapper _mapper;


        public SeasonsServiceModel(ISeasonsRepository seasonsRepository, IMapper mapper)
        {
            _seasonsRepository = seasonsRepository ?? throw new ArgumentNullException(nameof(seasonsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<SeasonDTO> GetAllSeasonsService()
        {
            var result = _seasonsRepository.GetAllSeasons();

            return _mapper.Map<IEnumerable<SeasonDTO>>(result);
        }

        public bool TVShowExistService(int showId)
        {
            return _seasonsRepository.TVShowExist(showId);
        }

        public IEnumerable<SeasonDTO> GetSeasonsService(int showId)
        {
            var result = _seasonsRepository.GetSeasons(showId);
            return _mapper.Map<IEnumerable<SeasonDTO>>(result);
        }
    }
}
