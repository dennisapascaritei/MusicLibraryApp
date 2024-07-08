
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : BaseController
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ArtistController(DataContext ctx, IMapper mapper, IMediator mediator)
        {
            _ctx = ctx;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArtists(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllArtistsQuery(), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);

            var mapped = _mapper.Map<List<ArtistResponse>>(result.Payload);

            return Ok(mapped);
        }

        [HttpGet]
        [Route("{artistId}")]
        [ValidateGuid("artistId")]
        public async Task<IActionResult> GetArtistById(string artistId, CancellationToken cancellationToken)
        {
            var artistGuid = Guid.Parse(artistId);
            var query = new GetArtistByIdQuery { ArtistId = artistGuid };
            var result = await _mediator.Send(query, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            var mapped = _mapper.Map<ArtistResponse>(result.Payload);

            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist(ArtistCreateRequest artist, CancellationToken cancellationToken)
        {
            var command = new ArtistCreateCommand
            {
                Name = artist.Name
            };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            var mapped = _mapper.Map<ArtistResponse>(result.Payload);

            return Ok(mapped);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArtist(ArtistUpdateRequest artist, CancellationToken cancellationToken)
        {
            var command = new ArtistUpdateCommand
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name
            };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);
            var mapped = _mapper.Map<ArtistResponse>(result.Payload);

            return Ok(mapped);
        }

        [HttpDelete]
        [Route("{artistId}")]
        [ValidateGuid("{artistId}")]
        public async Task<IActionResult> DeleteArtist(string artistId, CancellationToken cancellationToken)
        {
            var command = new ArtistDeleteCommand
            {
                ArtistId = Guid.Parse(artistId)
            };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            return NoContent();
        }

    }
}
