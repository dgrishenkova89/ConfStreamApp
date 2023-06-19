namespace ConfStream.Contracts.Dto
{
    public class ConferenceInfo
    {
        public int Id { get; set; }

        public int CountryId { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
