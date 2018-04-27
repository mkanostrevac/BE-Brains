using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4_P1_2.Models;

namespace T4_P1_2.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UsersRepository { get;}

        void Save();
    }
}
