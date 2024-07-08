
using Application.Albums.Queries;

namespace Application.Albums.QueriesHandler
{
    public class GetAllAlbumsQueryHandler : IRequestHandler<GetAllAlbumsQuery, OperationResult<List<Album>>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<List<Album>> _result = new OperationResult<List<Album>>();
        public GetAllAlbumsQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<List<Album>>> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var albums = request.ArtistId != null
                    ? await _ctx.Albums
                        .Include(a => a.Songs)
                        .Where(a => a.ArtistId == request.ArtistId)
                        .ToListAsync(cancellationToken)
                    : await _ctx.Albums
                        .Include(a => a.Songs)
                        .ToListAsync(cancellationToken);


                if (albums.Count == 0)
                {
                    _result.AddError(ErrorCode.NotFound, AlbumErrorMessages.AlbumListIsEmpty);
                    return _result;
                }

                _result.Payload = albums;

                return _result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
