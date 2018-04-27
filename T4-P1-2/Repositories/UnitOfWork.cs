using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using T4_P1_2.Models;
using Unity.Attributes;

namespace T4_P1_2.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;
        private IGenericRepository<User> usersRepository;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public IGenericRepository<User> UsersRepository
        {
            get
            {
                if (this.usersRepository == null)
                {
                    this.usersRepository = new GenericRepository<User>(this.context);
                }

                return usersRepository;
            }
        }

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