using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project.Models;
using Unity.Attributes;

namespace Project.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        [Dependency]
        public IGenericRepository<UserModel> UsersRepository { get; set; }

        [Dependency]
        public IGenericRepository<CategoryModel> CategoriesRepository { get; set; }

        [Dependency]
        public IGenericRepository<OfferModel> OffersRepository { get; set; }

        [Dependency]
        public IGenericRepository<BillModel> BillsRepository { get; set; }

        [Dependency]
        public IGenericRepository<VoucherModel> VouchersRepository { get; set; }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}