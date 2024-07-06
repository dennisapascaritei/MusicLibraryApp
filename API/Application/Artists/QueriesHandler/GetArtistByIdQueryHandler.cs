
using Application.Artists.Queries;

namespace Application.Artists.QueriesHandler
{
    public class GetArtistByIdQueryHandler : IRequestHandler<GetArtistByIdQuery, OperationResult<Artist>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Artist> _result = new OperationResult<Artist>();
        public GetArtistByIdQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Artist>> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await _ctx.Artists
                    .Include(a => a.Albums)
                    .FirstOrDefaultAsync(a => a.ArtistId == request.ArtistId, cancellationToken);

                if (artist == null)
                {
                    _result.AddError(ErrorCode.NotFound, string.Format(ArtistErrorMessages.ArtistNotFound, request.ArtistId));
                    return _result;
                }

                _result.Payload = artist;

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
