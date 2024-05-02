using TP_LABIV.Data.Entities;
using TP_LABIV.Data.Models;

namespace TP_LABIV.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User? GetUserById(int userId);
        User CreateUser(User user);
        User? UpdateUser(int userId, User updatedUser);
        bool DeleteUser(int userId);
        BaseResponse ValidateUser(string email);

        User? GetUserByEmail(string email);

    }
}
