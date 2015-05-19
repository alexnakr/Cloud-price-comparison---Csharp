using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using WebRole1.Models;

namespace WebRole1.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            //Table mapping
            this.ToTable("Product");

            //Primary key
            this.HasKey(p => p.Id);

            //Properties
            this.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.Name).IsRequired();

            //Relationship
            this.HasRequired(p => p.Receipt).WithMany(p => p.Products).HasForeignKey(p => p.ReceiptId);
        }
    }
}