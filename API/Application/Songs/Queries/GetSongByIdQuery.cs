
namespace Application.Songs.Queries
{
    public class GetSongByIdQuery: IRequest<OperationResult<Song>>
    {
        public Guid SongId { get; set; }
    }
}
