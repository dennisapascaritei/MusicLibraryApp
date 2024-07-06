using API.Contracts.Albums.Request;
using Domain.Models;

namespace API.Contracts.Artists.Request
{
    public class ArtistUpdateRequest
    {
        public Guid ArtistId { get; set; }
        public string Name { get; set; }
    }
}
