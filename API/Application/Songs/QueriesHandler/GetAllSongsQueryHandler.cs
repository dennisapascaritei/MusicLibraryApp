
using Application.Songs.Queries;

namespace Application.Songs.QueriesHandler
{
    public class GetAllSongsQueryHandler : IRequestHandler<GetAllSongsQuery, OperationResult<List<Song>>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<List<Song>> _result = new OperationResult<List<Song>>();
        public GetAllSongsQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<List<Song>>> Handle(GetAllSongsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var songs = await _ctx.Songs.ToListAsync(cancellationToken);

                if (songs.Count == 0)
                {
                    _result.AddError(ErrorCode.NotFound, SongErrorMessages.SongListIsEmpty);
                    return _result;
                }

                _result.Payload = songs;

                return _result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
