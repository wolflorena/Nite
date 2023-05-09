using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository;
using Nite.API.Repository.Entities;

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

        public SeasonDTO? GetSeasonService(int? showId, int? seasonId)
        {
            var result = _seasonsRepository.GetSeason(showId, seasonId);

            return (_mapper.Map<SeasonDTO>(result));
        }
        public SeasonDTO AddSeasonService(int showId, SeasonCreationDTO season)
        {
            var result = _mapper.Map<Season>(season);

            _seasonsRepository.AddSeason(showId, result);
            _seasonsRepository.Save();

            return _mapper.Map<SeasonDTO>(result);
        }

        public void UpdateWithPutSeason(int showId, int id, SeasonUpdateDTO season)
        {
            var seasonEntity = _seasonsRepository.GetSeason(showId, id);
            _mapper.Map(season, seasonEntity);
        }

        public void DeleteSeasonService(int showId, int id)
        {
            var result = _seasonsRepository.GetSeason(showId, id);

            _seasonsRepository.DeleteSeason(result);

            _seasonsRepository.Save();
        }

        public bool SaveService()
        {
            return _seasonsRepository.Save();
        }
    }
}
