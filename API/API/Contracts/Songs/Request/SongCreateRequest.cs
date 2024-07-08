
namespace API.Contracts.Songs.Request
{
    public class SongCreateRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public TimeSpan Length { get; set; } = TimeSpan.Zero;
        [Required]
        public Guid AlbumId { get; set; }
    }
}
