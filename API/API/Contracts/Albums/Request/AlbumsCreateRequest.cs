
namespace API.Contracts.Albums.Request
{
    public class AlbumsCreateRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid ArtistId { get; set; }

    }
}
