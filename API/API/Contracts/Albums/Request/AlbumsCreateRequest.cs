using API.Contracts.Songs.Request;
using Domain.Models;

namespace API.Contracts.Albums.Request
{
    public class AlbumsCreateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ArtistId { get; set; }

    }
}
