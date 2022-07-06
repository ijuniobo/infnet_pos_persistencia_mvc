using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Service
{
    public interface IPlaylistService
    {
        Task<PlaylistOutputDto> Atualizar(PlaylistInputDto dto);
        Task<PlaylistOutputDto> Criar(PlaylistInputDto dto);
        Task<PlaylistOutputDto> Deletar(PlaylistInputDto dto);
        Task<PlaylistOutputDto> ObterPorId(Guid id);
        Task<List<PlaylistOutputDto>> ObterTodos();
    }
}