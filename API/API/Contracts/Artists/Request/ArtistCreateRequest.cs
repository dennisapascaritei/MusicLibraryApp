
namespace API.Contracts.Artists.Request
{
    public class ArtistCreateRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
