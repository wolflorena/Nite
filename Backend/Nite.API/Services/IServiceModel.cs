using Nite.API.Data.Models;

namespace Nite.API.Services
{
    public interface IServiceModel
    {
        UserDTO? LoginRequestService(LoginDTO request);
        IEnumerable<UserDTO> GetUsersService();
        UserDTO GetUserService(int id);
        UserDTO AddUserService(UserCreationDTO user);
    }
}
