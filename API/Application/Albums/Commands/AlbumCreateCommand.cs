
namespace Application.Albums.Commands
{
    public class AlbumCreateCommand : IRequest<OperationResult<Album>>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid ArtistId { get; set; }

    }
}
