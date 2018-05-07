using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<UserModel> UsersRepository { get; }

        IGenericRepository<CategoryModel> CategoriesRepository { get; }

        IGenericRepository<OfferModel> OffersRepository { get; }

        IGenericRepository<BillModel> BillsRepository { get; }

        IGenericRepository<VoucherModel> VouchersRepository { get; }

        void Save();
    }
}
