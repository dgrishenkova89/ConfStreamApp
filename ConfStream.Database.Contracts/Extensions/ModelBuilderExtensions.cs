namespace ConfStream.Database.Common.Extensions
{
    using ConfStream.Database.Common.Models;
    using Microsoft.EntityFrameworkCore;

    public static class ModelBuilderExtensions
    {
        public static void ConfigureIdentity<T>(this ModelBuilder modelBuilder)
            where T : BaseEntity
        {
            string seqName = $"seq_{typeof(T).Name}";
            modelBuilder.HasSequence(seqName)
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.Entity<T>(t => t.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql($"nextval('\"{seqName}\"')"));
        }

        public static void ConfigureConcurrencyToken<T>(this ModelBuilder modelBuilder)
            where T : BaseEntity
        {
            modelBuilder.Entity<T>(t => t.Property(p => p.UpdatedAt)
                .IsConcurrencyToken());
        }

        public static void ApplyEntityCustomConfiguration<T>(this ModelBuilder modelBuilder, IEntityTypeConfiguration<T> entityConfig)
            where T : BaseEntity
        {
            modelBuilder.ConfigureIdentity<T>();
            modelBuilder.ConfigureConcurrencyToken<T>();

            modelBuilder.ApplyConfiguration(entityConfig);
        }
    }
}
