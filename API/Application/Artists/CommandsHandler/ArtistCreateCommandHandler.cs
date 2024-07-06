
namespace Application.Artists.CommandsHandler
{
    public class ArtistCreateCommandHandler : IRequestHandler<ArtistCreateCommand, OperationResult<Artist>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Artist> _result = new OperationResult<Artist>();
        public ArtistCreateCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Artist>> Handle(ArtistCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newArtist = Artist.CreateArtist(request.Name);                

                _ctx.Artists.Add(newArtist);
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
