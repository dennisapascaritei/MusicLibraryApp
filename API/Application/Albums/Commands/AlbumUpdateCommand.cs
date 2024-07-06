
namespace Application.Albums.Commands
{
    public class AlbumUpdateCommand : IRequest<OperationResult<Album>>
    {
        public Guid AlbumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ArtistId { get; set; }
    }
}
