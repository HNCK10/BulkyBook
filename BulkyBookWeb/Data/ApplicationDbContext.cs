using BulkyBookWeb.Models;
using BulkyBookWeb.Models.User;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<OneTimePin> OneTimePin { get; set; }
        public DbSet<Authenticate> Authenticate { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<ChangePassword> ChangePassword { get; set; }
        public DbSet<ResetPassword> ResetPassword { get; set; }
    }

}
