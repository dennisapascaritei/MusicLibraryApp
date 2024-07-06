using Domain.Models;

namespace API.Contracts.Songs.Request
{
    public class SongCreateRequest
    {
        public string Title { get; set; }
        public TimeSpan Length { get; set; } = TimeSpan.Zero;
        public Guid AlbumId { get; set; }
    }
}
