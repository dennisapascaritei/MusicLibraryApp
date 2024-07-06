
namespace Application.Artists.Commands
{
    public class ArtistCreateCommand : IRequest<OperationResult<Artist>>
    {
        public string Name { get; set; }
    }
}
