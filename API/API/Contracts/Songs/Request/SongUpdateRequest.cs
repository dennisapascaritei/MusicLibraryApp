
namespace API.Contracts.Songs.Request
{
    public class SongUpdateRequest
    {
        [Required]
        public Guid SongId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public TimeSpan Length { get; set; } = TimeSpan.Zero;
        [Required]
        public Guid AlbumId { get; set; }
    }
}

