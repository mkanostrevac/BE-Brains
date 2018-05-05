using System.Collections.Generic;
using Project.Models;

namespace Project.Services
{
    public interface IUsersService
    {
        IEnumerable<UserModel> GetAllUsers();

        UserModel GetUser(int id);

        UserModel CreateUser(UserModel newUser);

        UserModel UpdateUser(int userId, string firstName, string lastName, string username, string email);

        UserModel UpdateUserRole(int userId, UserRoles newRole);

        UserModel UpdatePassword(int userId, string oldPassword, string newPassword);

        UserModel DeleteUser(int userId);

        UserModel GetUserByUsername(string username);
    }
}
