
namespace Application.Songs.CommandsHandler
{
    public class SongCreateCommandHandler : IRequestHandler<SongCreateCommand, OperationResult<Song>>
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<Song> _result = new OperationResult<Song>();
        public SongCreateCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<Song>> Handle(SongCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newSong = Song.CreateSong(request.Title, request.Length, request.AlbumId);                

                _ctx.Songs.Add(newSong);
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
