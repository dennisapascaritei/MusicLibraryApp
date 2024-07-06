
namespace Application.Songs.CommandsHandler
{
    public class SongDeleteCommandHandler : IRequestHandler<SongDeleteCommand, OperationResult<Song>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Song> _result = new OperationResult<Song>();
        public SongDeleteCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Song>> Handle(SongDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var song = await _ctx.Songs.FirstOrDefaultAsync(a => a.SongId == request.SongId, cancellationToken);

                if (song == null)
                {
                    _result.AddError(ErrorCode.NotFound, string.Format(SongErrorMessages.SongNotFound, request.SongId));
                    return _result;
                }

                _ctx.Songs.Remove(song);
                await _ctx.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _result.AddUnknownError(ex.Message);
            }

            return _result;
        }
    }
}
