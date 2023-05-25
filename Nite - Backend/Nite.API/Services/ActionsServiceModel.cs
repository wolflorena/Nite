using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository;
using Nite.API.Repository.Entities;

namespace Nite.API.Services
{
    public class ActionsServiceModel : IActionsServiceModel
    {
        private readonly IActionsRepository _actionsRepository;
        private readonly IMapper _mapper;


        public ActionsServiceModel(IActionsRepository actionsRepository, IMapper mapper)
        {
            _actionsRepository = actionsRepository ?? throw new ArgumentNullException(nameof(actionsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<FavoritesDTO> GetAllFavoritesService(int userId)
        {
            var result = _actionsRepository.GetAllFavorites(userId);

            return _mapper.Map<IEnumerable<FavoritesDTO>>(result);
        }

        public IEnumerable<AddDTO> GetAllAddedShowsService(int userId)
        {
            var result = _actionsRepository.GetAllAddedShows(userId);

            return _mapper.Map<IEnumerable<AddDTO>>(result);
        }

        public IEnumerable<WatchDTO> GetAllWatchedEpisodesService(int userId)
        {
            var result = _actionsRepository.GetAllWatchedEpisodes(userId);

            return _mapper.Map<IEnumerable<WatchDTO>>(result);
        }

        public FavoritesDTO AddFavoriteService(FavoritesCreationDTO favorite)
        {
            var result = _mapper.Map<Favorites>(favorite);

            _actionsRepository.AddFavorite(result);
            _actionsRepository.Save();

            return _mapper.Map<FavoritesDTO>(result);
        }

        public AddDTO AddAddedShowService(AddCreationDTO added)
        {
            var result = _mapper.Map<Add>(added);

            _actionsRepository.AddAddedShow(result);
            _actionsRepository.Save();

            return _mapper.Map<AddDTO>(result);
        }

        public WatchDTO AddWatchedEpisodeService(WatchCreationDTO watched, int userId, int showId)
        {
            var result = _mapper.Map<Watch>(watched);

            if (_actionsRepository.ShowExistInAdded(userId, showId))
                DeleteAddedShowService(userId, showId);

            _actionsRepository.AddWatchedEpisode(result);
            _actionsRepository.Save();

            return _mapper.Map<WatchDTO>(result);
        }

        public FavoritesDTO? GetFavoriteService(int? userId, int? showId)
        {
            var result = _actionsRepository.GetFavorite(userId, showId);

            return (_mapper.Map<FavoritesDTO>(result));
        }

        public void DeleteFavoriteService(int userId, int showId)
        {
            var result = _actionsRepository.GetFavorite(userId, showId);

            _actionsRepository.DeleteFavorite(result);

            _actionsRepository.Save();
        }


        public AddDTO? GetAddedShowService(int? userId, int? showId)
        {
            var result = _actionsRepository.GetAddedShow(userId, showId);

            return (_mapper.Map<AddDTO>(result));
        }

        public void DeleteAddedShowService(int userId, int showId)
        {
            var result = _actionsRepository.GetAddedShow(userId, showId);

            _actionsRepository.DeleteAddedShow(result);

            _actionsRepository.Save();
        }

        public WatchDTO? GetWatchedEpisodeService(int? userId, int? showId, int? seasonId, int? episodeId)
        {
            var result = _actionsRepository.GetWatchedEpisode(userId, showId, seasonId, episodeId);

            return (_mapper.Map<WatchDTO>(result));
        }

        public void DeleteWatchedEpisodeService(int userId, int showId, int seasonId, int episodeId)
        {
            var result = _actionsRepository.GetWatchedEpisode(userId, showId, seasonId, episodeId);

            _actionsRepository.DeleteWatchedEpisode(result);

            _actionsRepository.Save();
        }

        public bool UserExistService(int userId)
        {
            return _actionsRepository.UserExist(userId);
        }

        public bool ShowExistService(int showId)
        {
            return _actionsRepository.ShowExist(showId);
        }

        public bool SeasonExistService(int seasonId)
        {
            return _actionsRepository.SeasonExist(seasonId);
        }

        public bool EpisodeExistService(int episodeId)
        {
            return _actionsRepository.EpisodeExist(episodeId);
        }
    }
}
