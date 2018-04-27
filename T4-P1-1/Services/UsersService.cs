using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T4_P1_1.Models;

namespace T4_P1_1.Services
{
    public class UsersService : IUsersService
    {
        public IEnumerable<User> GetActiveUsers()
        {
            List<User> users = new List<User>();

            users.Add(new User() { FirstName = "Ivan", LastName = "Vasiljevic" });
            users.Add(new User() { FirstName = "Mladen", LastName = "Kanostrevac" });

            return users;
        }
    }
}