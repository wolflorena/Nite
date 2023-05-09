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

        public bool TVShowExist(int showId)
        {
            return _context.TVShows.Any(a => a.Id == showId);
        }
    }
}
