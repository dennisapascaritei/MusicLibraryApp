namespace API.Contracts.Albums.Request
{
    public class AlbumUpdateRequest
    {
        public Guid AlbumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ArtistId { get; set; }
    }
}
