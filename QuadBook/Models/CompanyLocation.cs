using Microsoft.EntityFrameworkCore;
namespace QuadBook.Models
{
    public class CompanyLocation
    {
        public int LocationID { get; set; }
        public Location Location { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyLocation>()
                .HasKey(c => new { c.Company, c.Location });
        }

        public CompanyLocation()
        {

        }
    }
}
