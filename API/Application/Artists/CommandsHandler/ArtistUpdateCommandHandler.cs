
namespace Application.Artists.CommandsHandler
{
    public class ArtistUpdateCommandHandler : IRequestHandler<ArtistUpdateCommand, OperationResult<Artist>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Artist> _result = new OperationResult<Artist>();
        public ArtistUpdateCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Artist>> Handle(ArtistUpdateCommand request, CancellationToken cancellationToken)
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

                artist.UpdateArtist(request.Name);

                _ctx.Artists.Update(artist);
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
