using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using WebRole1.Models;

namespace WebRole1.Mappings
{
    public class StoreMap : EntityTypeConfiguration<Store>
    {
        public StoreMap()
        {
            //Table mapping
            this.ToTable("Store");

            //Primary key
            this.HasKey(s => s.Id);

            //Properties
            this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}