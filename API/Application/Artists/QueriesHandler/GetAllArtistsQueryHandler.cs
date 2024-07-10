

namespace Application.Artists.QueriesHandler
{
    public class GetAllArtistsQueryHandler : IRequestHandler<GetAllArtistsQuery, OperationResult<List<Artist>>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<List<Artist>> _result = new OperationResult<List<Artist>>();
        public GetAllArtistsQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<List<Artist>>> Handle(GetAllArtistsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artists = await _ctx.Artists
                    .ToListAsync(cancellationToken);

                if (artists.Count == 0)
                {
                    _result.AddError(ErrorCode.NotFound, ArtistErrorMessages.ArtistListIsEmpty);
                    return _result;
                }

                _result.Payload = artists;

                return _result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
