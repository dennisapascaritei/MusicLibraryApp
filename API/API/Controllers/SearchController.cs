
using Application.SearchEngine.Queries;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SearchController(DataContext ctx, IMapper mapper, IMediator mediator)
        {
            _ctx = ctx;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{searchItem}")]
        public async Task<IActionResult> SearchDateBase(string searchItem, CancellationToken cancellationToken)
        {
            var query = new GetSearchResultQuery()
            {
                SearchItem = searchItem
            };
            var result = await _mediator.Send(query, cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);

            var mapped = _mapper.Map<List<SearchResultResponse>>(result.Payload);

            return Ok(mapped);
        }
    }
}
