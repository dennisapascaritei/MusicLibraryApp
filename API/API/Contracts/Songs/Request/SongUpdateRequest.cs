namespace API.Contracts.Songs.Request
{
    public class SongUpdateRequest
    {
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public TimeSpan Length { get; set; } = TimeSpan.Zero;
        public Guid AlbumId { get; set; }
    }
}

