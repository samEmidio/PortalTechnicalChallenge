using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortalTechnicalChallenge.Domain.Core.Entity;
using PortalTechnicalChallenge.Domain.Entities;
using PortalTechnicalChallenge.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalTechnicalChallenge.Infra.Data.Context
{

    /// <summary>
    /// context
    /// </summary>
    public class PortalTechnicalChallengeContext : DbContext
    {
        private readonly IConfiguration _config;
        public PortalTechnicalChallengeContext()
        {
            //for test
        }
        public PortalTechnicalChallengeContext(DbContextOptions<PortalTechnicalChallengeContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseSqlServer(
                _config.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("portal_technical_challenge_migrationsLog"));
        }


        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified
                        || e.State == EntityState.Deleted));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }

            }

            return base.SaveChanges();
        }
    }
}
