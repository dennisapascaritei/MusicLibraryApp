using API.Contracts.Albums.Response;
using Domain.Models;

namespace API.Contracts.Artists.Response
{
    public class ArtistResponse
    {
        public Guid ArtistId { get; set; }
        public string Name { get; set; }
        public List<AlbumResponse> Albums { get; set; }
    }
}
