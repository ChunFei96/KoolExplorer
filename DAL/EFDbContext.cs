using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EFDbContext : IdentityDbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }

        public DbSet<CentreServices> CentreService { get; set; }
        public DbSet<Centres> Centres { get; set; }
        public DbSet<EnrolementRatio> EnrolementRatio { get; set; }
        public DbSet<KindergartenEnrolement> KindergartenEnrolement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CentreServices>().ToTable("CentreServices");
            modelBuilder.Entity<Centres>().ToTable("Centres");
            modelBuilder.Entity<EnrolementRatio>().ToTable("EnrolementRatio");
            modelBuilder.Entity<KindergartenEnrolement>().ToTable("KindergartenEnrolement");
        }
    }
}