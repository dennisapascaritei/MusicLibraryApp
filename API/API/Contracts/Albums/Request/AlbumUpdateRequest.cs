using System.ComponentModel.DataAnnotations;

namespace API.Contracts.Albums.Request
{
    public class AlbumUpdateRequest
    {
        [Required]
        public Guid AlbumId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid ArtistId { get; set; }
    }
}
