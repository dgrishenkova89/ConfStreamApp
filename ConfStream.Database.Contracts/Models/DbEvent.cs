namespace ConfStream.Database.Common.Models
{
    public class DbEvent : BaseEntity
    {
        public DateTimeOffset DateTimeSlot { get; set; }

        public int SpeakerId { get; set; }

        public virtual DbUser? Speaker { get; set; }

        public int RoomNumber { get; set; }
    }
}
