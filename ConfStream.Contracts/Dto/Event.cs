namespace ConfStream.Contracts.Dto
{
    public class Event
    {
        public int Id { get; set; } 

        public DateTimeOffset DateTimeSlot { get; set; }

        public int SpeakerId { get; set; }

        public User Speaker { get; set; }

        public int RoomNumber { get; set; }

        public int? VoteRatingId { get; set; }

        public VoteRating? VoteRating { get; set; }
    }
}
