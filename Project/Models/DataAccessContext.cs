﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("DataAccessConnection")
        {
            Database.SetInitializer<DataAccessContext>(new DataAccessContextInitializer());
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<OfferModel> Offers { get; set; }
        public DbSet<BillModel> Bills { get; set; }
        public DbSet<VoucherModel> Vouchers { get; set; }
    }
}