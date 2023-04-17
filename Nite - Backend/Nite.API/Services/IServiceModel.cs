using Nite.API.Data.Models;

namespace Nite.API.Services
{
    public interface IServiceModel
    {
        UserDTO? LoginRequestService(LoginDTO request);
        IEnumerable<UserDTO> GetUsersService();
        UserDTO GetUserService(int id);
        UserDTO AddUserService(UserCreationDTO user);

        void UpdateWithPutUser(int userId, UserUpdateDTO user);
        UserUpdateDTO UpdateWithPatchUser(int id);
        void UpdateUserFinishService(int id, UserUpdateDTO userToPatch);
        void DeleteUserService(int id);
        bool UserExistService(int userId);
        bool SaveService();
    }
}
