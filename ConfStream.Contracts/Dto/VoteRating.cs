namespace ConfStream.Contracts.Dto
{
    public class VoteRating
    {
        public int Id { get; set; }

        public short Rating { get; set; }

        public string Comment { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
