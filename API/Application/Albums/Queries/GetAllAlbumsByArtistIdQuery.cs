using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Albums.Queries
{
    public class GetAllAlbumsByArtistIdQuery: IRequest<OperationResult<List<Album>>>
    {
        public Guid ArtistId { get; set; }
    }
}
