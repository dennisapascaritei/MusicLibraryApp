
namespace Application.Albums.CommandsHandler
{
    public class AlbumCreateCommandHandler : IRequestHandler<AlbumCreateCommand, OperationResult<Album>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Album> _result = new OperationResult<Album>();
        public AlbumCreateCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Album>> Handle(AlbumCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var artist = await _ctx.Artists.FirstOrDefaultAsync(a => a.ArtistId == request.ArtistId);
                var newAlbum = Album.CreateAlbum(request.Title, request.Description, request.ArtistId);                

                _ctx.Albums.Add(newAlbum);

                await _ctx.SaveChangesAsync(cancellationToken);

                _result.Payload = newAlbum;
            }
            catch (Exception ex)
            {
                _result.AddUnknownError(ex.Message);
            }

            return _result;
        }
    }
}
