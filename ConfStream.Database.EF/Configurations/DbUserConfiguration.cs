namespace ConfStream.Database.EF.Configurations
{
    using ConfStream.Database.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DbUserConfiguration : IEntityTypeConfiguration<DbUser>
    {
        public virtual void Configure(EntityTypeBuilder<DbUser> builder)
        {
            builder.ToTable(@"tbl_UserInfos");

            builder.HasIndex(u => u.Email)
                   .IsUnique();

            builder.HasIndex(u => u.Phone)
                   .IsUnique();
        }
    }
}
