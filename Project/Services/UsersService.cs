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

        public UserModel CreateUser(UserModel user)
        {
            user.UserRole = UserRoles.ROLE_CUSTOMER;

            db.UsersRepository.Insert(user);
            db.Save();

            return user;
        }

        public UserModel UpdateUser(int id, string firstName, string lastName, string username, string email)
        {
            UserModel user = db.UsersRepository.GetByID(id);

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

        public UserModel UpdateUserRole(int id, UserRoles newRole)
        {
            UserModel user = db.UsersRepository.GetByID(id);

            if (user != null)
            {
                user.UserRole = newRole;
                db.UsersRepository.Update(user);
                db.Save();
            }

            return user;
        }

        public UserModel UpdatePassword(int id, string oldPassword, string newPassword)
        {
            UserModel user = db.UsersRepository.GetByID(id);

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

        public UserModel DeleteUser(int id)
        {
            UserModel user = db.UsersRepository.GetByID(id);

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