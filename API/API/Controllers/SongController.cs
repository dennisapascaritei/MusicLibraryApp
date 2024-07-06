using API.Contracts.Songs.Request;
using API.Contracts.Songs.Response;
using API.Filters;
using Application.Songs.Commands;
using Application.Songs.Queries;
using AutoMapper;
using Dal;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : BaseController
    {
        private readonly DataContext _ctx;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SongController(DataContext ctx, IMapper mapper, IMediator mediator)
        {
            _ctx = ctx;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSongs(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllSongsQuery(), cancellationToken);
            if (result.IsError) return HandleErrorResponse(result.Errors);

            var mapped = _mapper.Map<List<SongResponse>>(result.Payload);

            return Ok(mapped);
        }

        [HttpGet]
        [Route("{songId}")]
        [ValidateGuid("songId")]
        public async Task<IActionResult> GetSongById(string songId, CancellationToken cancellationToken)
        {
            var songGuid = Guid.Parse(songId);
            var query = new GetSongByIdQuery { SongId = songGuid };
            var result = await _mediator.Send(query, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            var mapped = _mapper.Map<SongResponse>(result.Payload);

            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(SongCreateRequest song, CancellationToken cancellationToken)
        {
            var command = new SongCreateCommand
            {
                Title = song.Title,
                Length = song.Length,
                AlbumId = song.AlbumId
            };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            var mapped = _mapper.Map<SongResponse>(result.Payload);

            return Ok(mapped);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSong(SongUpdateRequest song, CancellationToken cancellationToken)
        {
            var command = new SongUpdateCommand
            {
                SongId = song.SongId,
                Title = song.Title,
                Length = song.Length,
                AlbumId = song.AlbumId
            };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSong(SongDeleteRequest song, CancellationToken cancellationToken)
        {
            var command = new SongDeleteCommand
            {
                SongId = song.SongId
            };
            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError) return HandleErrorResponse(result.Errors);

            return NoContent();
        }

    }
}
