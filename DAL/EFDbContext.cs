using DAL.Entities;
using DAL.Entities.Form;
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
        public DbSet<ApplicationForm> ApplicationForm { get; set; }
        public DbSet<GeneralInformationItems> GeneralInformationItem { get; set; }
        public DbSet<ParentParticularItems> ParentParticularItem { get; set; }
        public DbSet<ChildParticularItems> ChildParticularItem { get; set; }
        public DbSet<ProcessedPreSchool> ProcessedPreSchool { get; set; }
        public DbSet<Programme> Programme { get; set; }
        public DbSet<LookUp> LookUp { get; set; }
        public DbSet<DropDownOptions> DropDownOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CentreServices>().ToTable("CentreServices");
            modelBuilder.Entity<Centres>().ToTable("Centres");
            modelBuilder.Entity<EnrolementRatio>().ToTable("EnrolementRatio");
            modelBuilder.Entity<KindergartenEnrolement>().ToTable("KindergartenEnrolement");
            modelBuilder.Entity<ApplicationForm>().ToTable("ApplicationForm");
            modelBuilder.Entity<GeneralInformationItems>().ToTable("GeneralInformationItems");
            modelBuilder.Entity<ParentParticularItems>().ToTable("ParentParticularItems");
            modelBuilder.Entity<ChildParticularItems>().ToTable("ChildParticularItems");
            modelBuilder.Entity<ProcessedPreSchool>().ToTable("ProcessedPreSchool");
            modelBuilder.Entity<Programme>().ToTable("Programme");
            modelBuilder.Entity<LookUp>().ToTable("LookUp");
            modelBuilder.Entity<DropDownOptions>().ToTable("DropDownOptions");
        }
    }
}