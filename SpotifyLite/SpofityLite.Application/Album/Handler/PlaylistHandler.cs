using MediatR;
using SpofityLite.Application.Album.Handler.Command;
using SpofityLite.Application.Album.Handler.Query;
using SpofityLite.Application.Album.Service;

namespace SpofityLite.Application.Album.Handler
{
    public class PlaylistHandler : IRequestHandler<CreatePlaylistCommand, CreatePlaylistCommandResponse>,
                                IRequestHandler<UpdatePlaylistCommand, UpdatePlaylistCommandResponse>,
                                IRequestHandler<DeletePlaylistCommand, DeletePlaylistCommandResponse>,
                                IRequestHandler<GetAllPlaylistQuery, GetAllPlaylistQueryResponse>,
                                IRequestHandler<GetPlaylistQuery, GetPlaylistQueryResponse>

    {
        private readonly IPlaylistService _playlistService;

        public PlaylistHandler(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        public async Task<CreatePlaylistCommandResponse> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.Criar(request.Playlist);
            return new CreatePlaylistCommandResponse(result);
        }

        public async Task<UpdatePlaylistCommandResponse> Handle(UpdatePlaylistCommand request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.Atualizar(request.Playlist);
            return new UpdatePlaylistCommandResponse(result);
        }

        public async Task<DeletePlaylistCommandResponse> Handle(DeletePlaylistCommand request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.Deletar(request.Playlist);
            return new DeletePlaylistCommandResponse(result);
        }

        public async Task<GetAllPlaylistQueryResponse> Handle(GetAllPlaylistQuery request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.ObterTodos();
            return new GetAllPlaylistQueryResponse(result);
        }

        public async Task<GetPlaylistQueryResponse> Handle(GetPlaylistQuery request, CancellationToken cancellationToken)
        {
            var result = await this._playlistService.ObterPorId(request.IdPlaylist);
            return new GetPlaylistQueryResponse(result);
        }
    }
}
