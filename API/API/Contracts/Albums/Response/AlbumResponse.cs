
namespace API.Contracts.Albums.Response
{
    public class AlbumResponse
    {
        public Guid AlbumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ArtistId { get; set; }
        public ArtistResponse Artist { get; set; }

        public List<SongResponse> Songs { get; set; }
    }
}
