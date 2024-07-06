

namespace Application.Songs.CommandsHandler
{
    public class SongUpdateCommandHandler : IRequestHandler<SongUpdateCommand, OperationResult<Song>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Song> _result = new OperationResult<Song>();
        public SongUpdateCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Song>> Handle(SongUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var song = await _ctx.Songs.FirstOrDefaultAsync(a => a.SongId == request.SongId, cancellationToken);

                if (song == null)
                {
                    _result.AddError(ErrorCode.NotFound, string.Format(SongErrorMessages.SongNotFound, request.SongId));
                    return _result;
                }

                var newSong = Song.CreateSong(request.Title, request.Length, request.AlbumId);

                song.UpdateSong(newSong);

                _ctx.Songs.Update(song);
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
