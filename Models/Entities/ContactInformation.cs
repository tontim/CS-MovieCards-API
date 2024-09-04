using System.ComponentModel.DataAnnotations;

namespace CS_MovieCards_API.Models.Entities
{
    public class ContactInformation
    {
        public Guid Id { get; set; }

        [MaxLength(30, ErrorMessage = "Max length 30.")]
        public String? Email { get; set; }

        [MaxLength(30, ErrorMessage = "Max length 30.")]
        public String? PhoneNumber { get; set; }
    }
}
