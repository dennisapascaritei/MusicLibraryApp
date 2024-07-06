
namespace Application.Albums.Commands
{
    public class AlbumDeleteCommand : IRequest<OperationResult<Album>>
    {
        public Guid AlbumId { get; set; }
    }
}
