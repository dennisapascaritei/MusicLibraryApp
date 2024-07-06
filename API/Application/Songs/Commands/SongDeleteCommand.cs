
namespace Application.Songs.Commands
{
    public class SongDeleteCommand : IRequest<OperationResult<Song>>
    {
        public Guid SongId { get; set; }
    }
}
