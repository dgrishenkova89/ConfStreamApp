namespace ConfStream.Database.EF.Configurations
{
    using ConfStream.Database.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DbCountryConfiguration : IEntityTypeConfiguration<DbCountry>
    {
        public virtual void Configure(EntityTypeBuilder<DbCountry> builder)
        {
            builder.ToTable(@"tbl_Countries");

            builder.HasIndex(u => u.Name)
                   .IsUnique();

            builder.HasIndex(u => u.AlphaCode2)
                   .IsUnique();
        }
    }
}
