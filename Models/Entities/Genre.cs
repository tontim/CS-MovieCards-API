using System.ComponentModel.DataAnnotations;

namespace CS_MovieCards_API.Models.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is requried.")]
        [MaxLength(30, ErrorMessage = "Max length 30.")]
        public String? Name { get; set; }
    }
}
