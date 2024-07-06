
namespace Application.Albums.CommandsHandler
{
    public class AlbumUpdateCommandHandler : IRequestHandler<AlbumUpdateCommand, OperationResult<Album>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Album> _result = new OperationResult<Album>();
        public AlbumUpdateCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Album>> Handle(AlbumUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var album = await _ctx.Albums
                    .Include(a => a.Songs)
                    .FirstOrDefaultAsync(a => a.AlbumId == request.AlbumId, cancellationToken);

                if (album == null)
                {
                    _result.AddError(ErrorCode.NotFound, string.Format(AlbumErrorMessages.AlbumNotFound, request.AlbumId));
                    return _result;
                }

                album.UpdateAlbum(request.Title, request.Description, request.ArtistId);

                _ctx.Albums.Update(album);
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
