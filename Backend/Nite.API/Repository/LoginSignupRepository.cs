using Nite.API.Data;
using Nite.API.Data.Models;
using Nite.API.Repository.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Nite.API.Repository
{
    public class LoginSignupRepository : ILoginSignupRepository
    {
        private readonly DataContext _context;

        public LoginSignupRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public User? LoginRequest(LoginDTO request)
        {
            foreach(var user in _context.Users)
            {
                if(user.Username == request.Username && user.Password == request.Password)
                {
                    return user;
                }
            }

            return null;
        }

        public IEnumerable<User> GetUsers() 
        { 
            return _context.Users.ToList();
        }

        public User? GetUser(int userId)
        {
            return _context.Users.Where(u => u.Id == userId).FirstOrDefault();
        }

        public void AddUser(User user) 
        {
            _context.Users.Add(user);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
