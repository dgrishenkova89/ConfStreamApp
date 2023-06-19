namespace ConfStream.Database.EF.Configurations
{
    using ConfStream.Database.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DbVoteRatingConfiguration : IEntityTypeConfiguration<DbVoteRating>
    {
        public virtual void Configure(EntityTypeBuilder<DbVoteRating> builder)
        {
            builder.ToTable(@"tbl_VoteRatings");
        }
    }
}
