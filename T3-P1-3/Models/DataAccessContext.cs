using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace T3_P1_3.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("DataAccessConnection")
        {
            Database.SetInitializer<DataAccessContext>(new DropCreateDatabaseIfModelChanges<DataAccessContext>());
        }

        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<T3_P1_3.Models.Address> Addresses { get; set; }
    }
}