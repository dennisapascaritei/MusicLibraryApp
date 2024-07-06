
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : BaseController
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AlbumController(DataContext ctx, IMapper mapper, IMediator mediator)
        {
            _ctx = ctx;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAlbums(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllAlbumsQuery(), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);

            var mapped = _mapper.Map<List<AlbumResponse>>(result.Payload);

            return Ok(mapped);
        }

        [HttpGet]
        [Route("{albumId}")]
        [ValidateGuid("albumId")]
        public async Task<IActionResult> GetAlbumById(string albumId, CancellationToken cancellationToken)
        {
            var albumGuid = Guid.Parse(albumId);
            var query = new GetAlbumByIdQuery { AlbumId = albumGuid };
            var result = await _mediator.Send(query, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            var mapped = _mapper.Map<AlbumResponse>(result.Payload);

            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum(AlbumsCreateRequest album, CancellationToken cancellationToken)
        {
            var command = new AlbumCreateCommand
            {
                Title = album.Title,
                Description = album.Description,
                ArtistId = album.ArtistId
            };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            var mapped = _mapper.Map<AlbumResponse>(result.Payload);

            return Ok(mapped);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAlbum(AlbumUpdateRequest album, CancellationToken cancellationToken)
        {
            var command = new AlbumUpdateCommand
            {
                AlbumId = album.AlbumId,
                Title = album.Title,
                Description = album.Description,
                ArtistId = album.ArtistId
            };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAlbum(AlbumDeleteRequest album, CancellationToken cancellationToken)
        {
            var command = new AlbumDeleteCommand
            {
                AlbumId = album.AlbumId
            };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            return NoContent();
        }

    }
}
