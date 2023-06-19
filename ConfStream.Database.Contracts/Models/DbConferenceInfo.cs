namespace ConfStream.Database.Common.Models
{
    public class DbConferenceInfo : BaseEntity
    {
        public int CountryId { get; set; }

        public virtual DbCountry Country { get; set; }

        public virtual ICollection<DbEvent> Events { get; set; }
    }
}
