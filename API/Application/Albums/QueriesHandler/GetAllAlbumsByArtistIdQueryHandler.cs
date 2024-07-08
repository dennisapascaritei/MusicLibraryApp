using Application.Albums.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Albums.QueriesHandler
{
    public class GetAllAlbumsByArtistIdQueryHandler
    {
        private readonly DataContext _ctx;
        private readonly OperationResult<List<Album>> _result = new OperationResult<List<Album>>();
        public GetAllAlbumsByArtistIdQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<List<Album>>> Handle(GetAllAlbumsByArtistIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var albums = await _ctx.Albums
                    .Include(a => a.Songs)
                    .Where(a => a.ArtistId == request.ArtistId)
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
