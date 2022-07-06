using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;
using SpotifyLite.Domain.Album.Repository;

namespace SpotifyLite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator mediator;

        public AlbumController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetAllAlbumQuery()));
        }

        [HttpGet("ObterPorId")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new GetAlbumQuery(id)));
        }

        [HttpPost()]
        public async Task<IActionResult> Criar(AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new CreateAlbumCommand(dto));
            return Created($"{result.Album.Id}", result.Album);
        }

        [HttpPut()]
        public async Task<IActionResult> Atualizar(AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new UpdateAlbumCommand(dto));
            return Ok(result.Album);
        }

        [HttpDelete()]
        public async Task<IActionResult> Apagar(AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new DeleteAlbumCommand(dto));
            return Ok(result.Album);
        }

    }
}
