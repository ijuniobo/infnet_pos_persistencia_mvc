using SpofityLite.Application.Album.Dto;

namespace SpofityLite.Application.Album.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Atualizar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> Criar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> Deletar(UsuarioInputDto dto);
        Task<UsuarioOutputDto> ObterPorId(Guid id);
        Task<List<UsuarioOutputDto>> ObterTodos();
    }
}