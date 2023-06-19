namespace ConfStream.Database.EF
{
    using ConfStream.Database.Common.Extensions;
    using ConfStream.Database.Common.Models;
    using ConfStream.Database.EF.Configurations;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<DbCountry> Countries { get; set; }

        public DbSet<DbUser> Users { get; set; }

        public DbSet<DbVoteRating> Votes { get; set; }

        public DbSet<DbEvent> Events { get; set; }

        public DbSet<DbConferenceInfo> Conferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyEntityCustomConfiguration(new DbUserConfiguration());
            modelBuilder.ApplyEntityCustomConfiguration(new DbUserConfiguration());
            modelBuilder.ApplyEntityCustomConfiguration(new DbUserConfiguration());
            modelBuilder.ApplyEntityCustomConfiguration(new DbUserConfiguration());
            modelBuilder.ApplyEntityCustomConfiguration(new DbUserConfiguration());
        }
    }
}
