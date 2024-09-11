using System.ComponentModel.DataAnnotations;

namespace CS_MovieCards_API.Models.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Movie title is required.")]
        [MaxLength(50, ErrorMessage = "Max length is 50 characters.")]
        public string? Title { get; set; }

        public int Rating { get; set; }

        [Required(ErrorMessage = "Releasedate is required.")]
        public DateTime ReleaseDate { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum of 500 characters.")]
        public string? Description { get; set; }

        //Navigation property
        public ICollection<Director>? Directors { get; set; }
    }
}
