using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogManagement.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Blogs> Blog { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<BlogManagement.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}

