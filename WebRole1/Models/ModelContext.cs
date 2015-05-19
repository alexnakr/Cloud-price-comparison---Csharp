using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebRole1.Models;
using WebRole1.Mappings;

namespace WebRole1
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name = PriceCompareDB")
        { 
        }

        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReceiptMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new StoreMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}