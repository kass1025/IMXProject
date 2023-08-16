using DIMS.Entities;
using DIMS.Entities.Account;
using DIMS.Entities.LanguagesEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIMS.DIMSDataContext
{

    public partial class DIMSDbContext : IdentityDbContext<ApplicationUsers>
    {
        public DIMSDbContext(DbContextOptions<DIMSDbContext> options)
             : base(options)
        {

        }
        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchItem> BranchItems { get; set; }
        public DbSet<CapitalSource> CapitalSources { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<EducationInformation> EducationInformation { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<EducationType> EducationTypes { get; set; }
        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<EnterpriseAddressInfo> EnterpriseAddressInfos { get; set; }
        public DbSet<EnterpriseLevel> EnterpriseLevels { get; set; }
        public DbSet<EnterpriseStatus> EnterpriseStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberAddressInfo> MemberAddressInfos { get; set; }
        public DbSet<MemberType> MemberTypes { get; set; }
        public DbSet<PromotionLevel> PromotionLevels { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Woreda> Woredas { get; set; }
        public DbSet<Disability> Disabilities { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }


        //Localization
        public virtual DbSet<Language> Languages { get; set; }
        public DbSet<StringResource> StringResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Culture).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<StringResource>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(50);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.StringResources)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_StringResources_Languages");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

