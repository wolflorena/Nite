using Nite.API.Data.Models;
using Nite.API.Repository.Entities;

namespace Nite.API.Repository
{
    public interface ILoginSignupRepository
    {
        User? LoginRequest(LoginDTO request);
        IEnumerable<User> GetUsers();
        User? GetUser(int userId);
        void AddUser(User user);

        bool Save();
    }
}
