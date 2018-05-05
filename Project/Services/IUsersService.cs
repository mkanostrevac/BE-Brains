using System.Collections.Generic;
using Project.Models;

namespace Project.Services
{
    public interface IUsersService
    {
        IEnumerable<UserModel> GetAllUsers();

        UserModel GetUser(int id);

        UserModel CreateUser(UserModel user);

        UserModel UpdateUser(int id, string firstName, string lastName, string username, string email);

        UserModel UpdateUserRole(int id, UserRoles newRole);

        UserModel UpdatePassword(int id, string oldPassword, string newPassword);

        UserModel DeleteUser(int id);

        UserModel GetUserByUsername(string username);
    }
}
