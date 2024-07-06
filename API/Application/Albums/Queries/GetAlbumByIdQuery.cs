
namespace Application.Albums.Queries
{
    public class GetAlbumByIdQuery: IRequest<OperationResult<Album>>
    {
        public Guid AlbumId { get; set; }
    }
}
