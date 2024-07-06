
namespace Application.Artists.Commands
{
    public class ArtistUpdateCommand : IRequest<OperationResult<Artist>>
    {
        public Guid ArtistId { get; set; }
        public string Name { get; set;}
    }
}
