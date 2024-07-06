
namespace Application.Songs.Commands
{
    public class SongCreateCommand : IRequest<OperationResult<Song>>
    {
        public string Title { get; set; }
        public TimeSpan Length { get; set; }
        public Guid AlbumId { get; set; }
    }
}
