
namespace Application.Albums.QueriesHandler
{
    public class GetAlbumByIdQueryHandler : IRequestHandler<GetAlbumByIdQuery, OperationResult<Album>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Album> _result = new OperationResult<Album>();
        public GetAlbumByIdQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Album>> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
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

                _result.Payload = album;

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
