namespace ConfStream.Database.Common.Models
{
    public class DbVoteRating : BaseEntity
    {
        public short Rating { get; set; }

        public string Comment { get; set; }

        public int EventId { get; set; }

        public virtual DbEvent Event { get; set; }
    }
}
