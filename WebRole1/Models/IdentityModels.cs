using Microsoft.AspNet.Identity.EntityFramework;

namespace WebRole1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("PriceCompareDB")
        {
        }

        public System.Data.Entity.DbSet<WebRole1.Models.Receipt> Receipts { get; set; }

        public System.Data.Entity.DbSet<WebRole1.Models.Store> Stores { get; set; }

        public System.Data.Entity.DbSet<WebRole1.Models.Product> Products { get; set; }
    }
}