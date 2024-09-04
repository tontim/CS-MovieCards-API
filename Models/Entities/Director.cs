using System.ComponentModel.DataAnnotations;

namespace CS_MovieCards_API.Models.Entities
{
    public class Director
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is requried.")]
        [MaxLength(30, ErrorMessage = "Max length 30.")]
        public String Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        //Foreign key
        public Guid MovieId { get; set; }

        //Navigation property
        public Movie? Movie { get; set; }
    }
}
