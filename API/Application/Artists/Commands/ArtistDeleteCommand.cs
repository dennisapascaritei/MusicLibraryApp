
namespace Application.Artists.Commands
{
    public class ArtistDeleteCommand : IRequest<OperationResult<Artist>>
    {
        public Guid ArtistId { get; set; }
    }
}
