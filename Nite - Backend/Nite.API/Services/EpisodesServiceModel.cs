using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository.Entities;
using Nite.API.Repository;

namespace Nite.API.Services
{
    public class EpisodesServiceModel : IEpisodesServiceModel
    {
        private readonly IEpisodesRepository _episodesRepository;
        private readonly IMapper _mapper;


        public EpisodesServiceModel(IEpisodesRepository episodesRepository, IMapper mapper)
        {
            _episodesRepository = episodesRepository ?? throw new ArgumentNullException(nameof(episodesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<EpisodeDTO> GetAllEpisodesService()
        {
            var result = _episodesRepository.GetAllEpisodes();

            return _mapper.Map<IEnumerable<EpisodeDTO>>(result);
        }

        public bool TVShowExistService(int showId)
        {
            return _episodesRepository.TVShowExist(showId);
        }

        public bool SeasonExistService(int showId, int seasonId)
        {
            return _episodesRepository.SeasonExist(showId, seasonId);
        }

        public IEnumerable<EpisodeDTO> GetEpisodesService(int showId, int seasonId)
        {
            var result = _episodesRepository.GetEpisodes(showId, seasonId);
            return _mapper.Map<IEnumerable<EpisodeDTO>>(result);
        }

        public EpisodeDTO? GetEpisodeService(int? showId, int? seasonId, int? episodeId)
        {
            var result = _episodesRepository.GetEpisode(showId, seasonId, episodeId);

            return (_mapper.Map<EpisodeDTO>(result));
        }
        public EpisodeDTO AddEpisodeService(int showId, int seasonId, EpisodeCreationDTO episode)
        {
            var result = _mapper.Map<Episode>(episode);

            _episodesRepository.AddEpisode(showId, seasonId, result);
            _episodesRepository.Save();

            return _mapper.Map<EpisodeDTO>(result);
        }

        public void UpdateWithPutEpisode(int showId, int seasonId, int id, EpisodeUpdateDTO episode)
        {
            var episodeEntity = _episodesRepository.GetEpisode(showId, seasonId, id);
            _mapper.Map(episode, episodeEntity);
        }

        public void DeleteEpisodeService(int showId, int seasonId, int id)
        {
            var result = _episodesRepository.GetEpisode(showId, seasonId, id);

            _episodesRepository.DeleteEpisode(result);

            _episodesRepository.Save();
        }

        public bool SaveService()
        {
            return _episodesRepository.Save();
        }
    }
}
