using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using WebRole1.Models;

namespace WebRole1.Mappings
{
    public class ReceiptMap : EntityTypeConfiguration<Receipt>
    {
        public ReceiptMap()
        {
            //Table mapping
            this.ToTable("Receipt");

            //Primary key
            this.HasKey(r => r.Id);

            //Properties
            this.Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Relationship
            this.HasRequired(r => r.Store).WithMany(s => s.Receipts).HasForeignKey(s => s.StoreId);
        }
    }
}