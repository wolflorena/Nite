using Nite.API.Data;
using Nite.API.Migrations;
using Nite.API.Repository.Entities;

namespace Nite.API.Repository
{
    public class ActionsRepository : IActionsRepository
    {
        private readonly DataContext _context;

        public ActionsRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Favorites> GetAllFavorites(int userId)
        {
            return _context.Favorites.Where(s => s.UserId == userId).ToList();
        }

        public IEnumerable<Add> GetAllAddedShows(int userId)
        {
            return _context.Added.Where(s => s.UserId == userId).ToList();
        }

        public IEnumerable<Watch> GetAllWatchedEpisodes(int userId)
        {
            return _context.Watched.Where(s => s.UserId == userId).ToList();
        }

        public void AddFavorite(Favorites favorite)
        {
            _context.Favorites.Add(favorite);
        }

        public void AddAddedShow(Add added)
        {
            _context.Added.Add(added);
        }

        public void AddWatchedEpisode(Watch watched)
        {
            _context.Watched.Add(watched);
        }

        public bool ShowExistInAdded(int? userId, int? showId)
        {
            return _context.Added.Any(d => d.UserId == userId && d.TVShowId == showId);
        }

        public Favorites? GetFavorite(int? userId, int? showId)
        {
            return _context.Favorites.Where(d => d.UserId == userId && d.TVShowId == showId).FirstOrDefault();
        }

        public void DeleteFavorite(Favorites favorite)
        {
            _context.Favorites.Remove(favorite);
        }

        public Add? GetAddedShow(int? userId, int? showId)
        {
            return _context.Added.Where(d => d.UserId == userId && d.TVShowId == showId).FirstOrDefault();
        }

        public void DeleteWatchedEpisode(Watch watched)
        {
            _context.Watched.Remove(watched);
        }

        public Watch? GetWatchedEpisode(int? userId, int? showId, int? seasonId, int? episodeId)
        {
            return _context.Watched.Where(d => d.UserId == userId && d.TVShowId == showId && d.SeasonId == seasonId && d.EpisodeId == episodeId).FirstOrDefault();
        }

        public void DeleteAddedShow(Add added)
        {
            _context.Added.Remove(added);
        }


        public bool UserExist(int userId)
        {
            return _context.Users.Any(a => a.Id == userId);
        }

        public bool ShowExist(int showId)
        {
            return _context.TVShows.Any(a => a.Id == showId);
        }

        public bool SeasonExist(int seasonId)
        {
            return _context.TVShowSeasons.Any(a => a.Id == seasonId);
        }

        public bool EpisodeExist(int episodeId)
        {
            return _context.Episodes.Any(a => a.Id == episodeId);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
