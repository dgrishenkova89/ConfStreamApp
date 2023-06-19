namespace ConfStream.Database.Common.Models
{
    public class DbUser : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string Phone { get; set; }

        public string PhotoUrl { get; set; }

        public int CountryId { get; set; }

        public virtual DbCountry Country { get; set; }

        public short UserRole { get; set; }
    }
}
