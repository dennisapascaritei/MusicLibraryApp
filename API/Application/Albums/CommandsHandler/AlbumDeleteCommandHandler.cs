
namespace Application.Albums.CommandsHandler
{
    public class AlbumDeleteCommandHandler : IRequestHandler<AlbumDeleteCommand, OperationResult<Album>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Album> _result = new OperationResult<Album>();
        public AlbumDeleteCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Album>> Handle(AlbumDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var album = await _ctx.Albums.FirstOrDefaultAsync(a => a.AlbumId == request.AlbumId, cancellationToken);

                if (album == null)
                {
                    _result.AddError(ErrorCode.NotFound, string.Format(AlbumErrorMessages.AlbumNotFound, request.AlbumId));
                    return _result;
                }

                _ctx.Albums.Remove(album);
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
