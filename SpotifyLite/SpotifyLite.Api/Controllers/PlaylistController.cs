using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;
using SpotifyLite.Domain.Account.Repository;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlaylistController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetAllPlaylistQuery()));
        }

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetPlaylistQuery(id)));
        }

        [HttpPost()]
        public async Task<IActionResult> Criar(PlaylistInputDto dto)
        {
            var result = await this.mediator.Send(new CreatePlaylistCommand(dto));
            return Created($"{result.Playlist.Id}", result.Playlist);
        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar(PlaylistInputDto dto)
        {
            var result = await this.mediator.Send(new UpdatePlaylistCommand(dto));
            return Ok(result.Playlist);
        }

        [HttpDelete()]
        public async Task<IActionResult> Apagar(PlaylistInputDto dto)
        {
            var result = await this.mediator.Send(new DeletePlaylistCommand(dto));
            return Ok(result.Playlist);
        }

    }
}
