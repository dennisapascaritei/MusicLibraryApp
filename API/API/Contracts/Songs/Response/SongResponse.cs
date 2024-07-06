namespace API.Contracts.Songs.Response
{
    public class SongResponse
    {
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public TimeSpan Length { get; set; } = TimeSpan.Zero;
        public Guid AlbumId { get; set; }
        public AlbumResponse Album { get; set; }
    }
}
