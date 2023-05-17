using Nite.API.Data;
using Nite.API.Repository.Entities;

namespace Nite.API.Repository
{
    public class EpisodesRepository : IEpisodesRepository
    {
        private readonly DataContext _context;

        public EpisodesRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Episode> GetAllEpisodes()
        {
            return _context.Episodes.ToList();
        }

        public IEnumerable<Episode> GetEpisodes(int showId, int seasonId)
        {
            return _context.Episodes.Where(s => s.TVShowId == showId && s.SeasonId == seasonId).ToList();
        }

        public Episode? GetEpisode(int? showId, int? seasonId, int? episodeId)
        {
            return _context.Episodes.Where(d => d.TVShowId == showId && d.SeasonId == seasonId && d.Id == episodeId).FirstOrDefault();
        }
        public TVShow? GetTVShow(int showId)
        {
            return _context.TVShows.Where(u => u.Id == showId).FirstOrDefault();
        }

        public Season? GetSeason(int showId, int seasonId)
        {
            return _context.TVShowSeasons.Where(u => u.Id == seasonId && u.TVShowId == showId).FirstOrDefault();
        }

        public void AddEpisode(int showId, int seasonId, Episode episode)
        {
            var season = GetSeason(showId, seasonId);
            season.Episodes.Add(episode);
        }

        public void DeleteEpisode(Episode episode)
        {
            _context.Episodes.Remove(episode);
        }

        public bool TVShowExist(int showId)
        {
            return _context.TVShows.Any(a => a.Id == showId);
        }

        public bool SeasonExist(int showId, int seasonId)
        {
            return _context.TVShowSeasons.Any(a => a.Id == seasonId && a.TVShowId == showId);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
