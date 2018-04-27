using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4_P1_1.Models;

namespace T4_P1_1.Services
{
    public interface IUsersService
    {
        IEnumerable<User> GetActiveUsers();
    }
}
