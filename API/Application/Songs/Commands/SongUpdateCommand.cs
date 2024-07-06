
namespace Application.Songs.Commands
{
    public class SongUpdateCommand : IRequest<OperationResult<Song>>
    {
        public Guid SongId { get; set; }
        public string Title { get; set;}
        public TimeSpan Length { get; set;}
        public Guid AlbumId { get; set;}
    }
}
