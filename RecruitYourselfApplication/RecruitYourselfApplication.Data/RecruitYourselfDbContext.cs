namespace RecruitYourselfApplication.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class RecruitYourselfDbContext : IdentityDbContext<User>, IRecruitYourselfDbContext
    {
        private static readonly RecruitYourselfDbContext context = new RecruitYourselfDbContext();
        
        public RecruitYourselfDbContext()
            : base("RecruitYourself", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RecruitYourselfDbContext, Configuration>());
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<Organization> Organizations { get; set; }

        public virtual IDbSet<Volunteer> Volunteers { get; set; }

        public static RecruitYourselfDbContext Create()
        {
            return new RecruitYourselfDbContext();
        }

        DbEntityEntry IRecruitYourselfDbContext.Entry<T>(T entity)
        {
            return this.Entry<T>(entity);
        }

        IDbSet<T> IRecruitYourselfDbContext.Set<T>()
        {
            return this.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Event>()
            //    .HasRequired(a => a.Creator)
            //    .WithMany(u => u.)
            //    .HasForeignKey(a => a.CreatorId)
            //    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Volunteer>().ToTable("Volunteers");
            modelBuilder.Entity<Organization>().ToTable("Organizations");

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
