﻿
namespace Application.Albums.Queries
{
    public class GetAllAlbumsQuery:IRequest<OperationResult<List<Album>>>
    {
        public Guid? ArtistId { get; set; }
    }
}
