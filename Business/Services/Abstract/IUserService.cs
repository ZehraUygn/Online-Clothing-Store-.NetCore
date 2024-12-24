using Business.Models;

namespace Business.Services.Abstract
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
        UserDto GetUserById(int id);
        UserDto InsertUser(UserDto model);
        UserDto UpdateUser(UserDto model);
        bool DeleteUser(int id);
    }
}
