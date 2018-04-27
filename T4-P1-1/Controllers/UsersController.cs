using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using T4_P1_1.Models;
using T4_P1_1.Services;

namespace T4_P1_1.Controllers
{
    public class UsersController : ApiController
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IEnumerable<User> GetActiveUsers()
        {
            return usersService.GetActiveUsers();
        }
    }
}
