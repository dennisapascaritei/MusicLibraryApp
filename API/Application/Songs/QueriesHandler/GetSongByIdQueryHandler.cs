
namespace Application.Songs.QueriesHandler
{
    public class GetSongByIdQueryHandler : IRequestHandler<GetSongByIdQuery, OperationResult<Song>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Song> _result = new OperationResult<Song>();
        public GetSongByIdQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Song>> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var song = await _ctx.Songs.FirstOrDefaultAsync(a => a.SongId == request.SongId, cancellationToken);

                if (song == null)
                {
                    _result.AddError(ErrorCode.NotFound, string.Format(SongErrorMessages.SongNotFound, request.SongId));
                    return _result;
                }

                _result.Payload = song;

                return _result;
            }
            catch (Exception ex)
            {
                _result.AddUnknownError(ex.Message);
            }

            return _result;
        }
    }
}
