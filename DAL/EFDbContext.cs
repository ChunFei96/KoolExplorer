using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }

        public DbSet<CentreServices> CentreService { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CentreServices>().ToTable("CentreServices");
        }
    }
}