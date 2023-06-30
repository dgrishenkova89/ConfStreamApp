using ConfStream.Contracts.Enums;

namespace ConfStream.Contracts.Dto
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public int CountryId { get; set; }

        public SystemRole UserRole { get; set; }
    }
}
