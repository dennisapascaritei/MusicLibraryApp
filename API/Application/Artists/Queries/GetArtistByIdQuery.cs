
namespace Application.Artists.Queries
{
    public class GetArtistByIdQuery: IRequest<OperationResult<Artist>>
    {
        public Guid ArtistId { get; set; }
    }
}
