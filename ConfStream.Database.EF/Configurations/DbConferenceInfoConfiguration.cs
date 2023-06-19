namespace ConfStream.Database.EF.Configurations
{
    using ConfStream.Database.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DbConferenceInfoConfiguration : IEntityTypeConfiguration<DbConferenceInfo>
    {
        public virtual void Configure(EntityTypeBuilder<DbConferenceInfo> builder)
        {
            builder.ToTable(@"tbl_ConferenceInfos");
        }
    }
}
