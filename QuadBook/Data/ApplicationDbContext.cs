using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuadBook.Models;

namespace QuadBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<QuadBook.Models.Booking> Booking { get; set; }
        public DbSet<QuadBook.Models.Company> Company { get; set; }
    }
}