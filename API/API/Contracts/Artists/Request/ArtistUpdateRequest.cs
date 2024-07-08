
namespace API.Contracts.Artists.Request
{
    public class ArtistUpdateRequest
    {
        [Required]
        public Guid ArtistId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
