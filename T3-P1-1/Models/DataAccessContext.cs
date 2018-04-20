using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace T3_P1_1.Models
{
    public class DataAccessContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataAccessContext(): 
            base("DataAccessConnection")
        {
            Database.SetInitializer<DataAccessContext>(new DropCreateDatabaseIfModelChanges<DataAccessContext>());
        }
    }
}