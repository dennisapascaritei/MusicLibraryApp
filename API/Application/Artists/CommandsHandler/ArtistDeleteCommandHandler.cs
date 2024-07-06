
namespace Application.Artists.CommandsHandler
{
    public class ArtistDeleteCommandHandler : IRequestHandler<ArtistDeleteCommand, OperationResult<Artist>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Artist> _result = new OperationResult<Artist>();
        public ArtistDeleteCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Artist>> Handle(ArtistDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await _ctx.Artists.FirstOrDefaultAsync(a => a.ArtistId == request.ArtistId, cancellationToken);

                if (artist == null)
                {
                    _result.AddError(ErrorCode.NotFound, string.Format(ArtistErrorMessages.ArtistNotFound, request.ArtistId));
                    return _result;
                }

                _ctx.Artists.Remove(artist);
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
