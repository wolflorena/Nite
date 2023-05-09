using Nite.API.Data;
using Nite.API.Repository.Entities;

namespace Nite.API.Repository
{
    public class SeasonsRepository : ISeasonsRepository
    {
        private readonly DataContext _context;

        public SeasonsRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Season> GetAllSeasons()
        {
            return _context.TVShowSeasons.ToList();
        }

        public IEnumerable<Season> GetSeasons(int showId)
        {
            return _context.TVShowSeasons.Where(s => s.TVShowId == showId).ToList();
        }

        public Season? GetSeason(int? showId, int? seasonId)
        {

            return _context.TVShowSeasons.Where(d => d.TVShowId == showId && d.Id == seasonId).FirstOrDefault();
        }
        public TVShow? GetTVShow(int showId)
        {
            return _context.TVShows.Where(u => u.Id == showId).FirstOrDefault();
        }

        public void AddSeason(int showId, Season season)
        {
            var show = GetTVShow(showId);
            show.TVShowSeasons.Add(season);
        }

        public void DeleteSeason(Season season)
        {
            _context.TVShowSeasons.Remove(season);
        }

        public bool TVShowExist(int showId)
        {
            return _context.TVShows.Any(a => a.Id == showId);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
