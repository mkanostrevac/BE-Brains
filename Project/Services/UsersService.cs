using System.Collections.Generic;
using System.Linq;
using Project.Models;
using Project.Repositories;

namespace Project.Services
{
    public class UsersService : IUsersService
    {
        private IUnitOfWork db;

        public UsersService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return db.UsersRepository.Get();
        }

        public UserModel GetUser(int id)
        {
            return db.UsersRepository.GetByID(id);
        }

        public UserModel CreateUser(UserModel newUser)
        {
            newUser.UserRole = UserRoles.ROLE_CUSTOMER;

            db.UsersRepository.Insert(newUser);
            db.Save();

            return newUser;
        }

        public UserModel UpdateUser(int userId, string firstName, string lastName, string username, string email)
        {
            UserModel user = db.UsersRepository.GetByID(userId);

            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                user.Username = username;
                user.Email = email;

                db.UsersRepository.Update(user);
                db.Save();
            }

            return user;
        }

        public UserModel UpdateUserRole(int userId, UserRoles newRole)
        {
            UserModel user = db.UsersRepository.GetByID(userId);

            if (user != null)
            {
                user.UserRole = newRole;
                db.UsersRepository.Update(user);
                db.Save();
            }

            return user;
        }

        public UserModel UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            UserModel user = db.UsersRepository.GetByID(userId);

            if (user != null)
            {
                if (user.Password == oldPassword)
                {
                    user.Password = newPassword;
                }

                db.UsersRepository.Update(user);
                db.Save();
            }

            return user;
        }

        public UserModel DeleteUser(int userId)
        {
            UserModel user = db.UsersRepository.GetByID(userId);

            if (user != null)
            {
                db.UsersRepository.Delete(user);
                db.Save();
            }

            return user;
        }

        public UserModel GetUserByUsername(string username)
        {
            return db.UsersRepository.Get(x => x.Username == username).FirstOrDefault();
        }
    }
}