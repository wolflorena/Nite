using Microsoft.EntityFrameworkCore;
using Nite.API.Data;
using Nite.API.Repository.Entities;

namespace Nite.API.Repository
{
    public class TVShowsRepository : ITVShowsRepository
    {
        private readonly DataContext _context;

        public TVShowsRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<TVShow> GetTVShows()
        {
            return _context.TVShows.ToList();
        }


        public TVShow? GetTVShow(int showId)
        {
            return _context.TVShows.Where(u => u.Id == showId).FirstOrDefault();
        }

        public void AddTVShow(TVShow show)
        {
            _context.TVShows.Add(show);
        }


        public void DeleteTVShow(TVShow show)
        {
            _context.TVShows.Remove(show);
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
