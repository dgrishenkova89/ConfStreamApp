namespace ConfStream.Database.EF.Configurations
{
    using ConfStream.Database.Common.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DbEventConfiguration : IEntityTypeConfiguration<DbEvent>
    {
        public virtual void Configure(EntityTypeBuilder<DbEvent> builder)
        {
            builder.ToTable(@"tbl_Events");

            builder.HasIndex($"{nameof(DbEvent.DateTimeSlot)}", $"{nameof(DbEvent.SpeakerId)}", $"{nameof(DbEvent.RoomNumber)}")
                   .IsUnique();
        }
    }
}
