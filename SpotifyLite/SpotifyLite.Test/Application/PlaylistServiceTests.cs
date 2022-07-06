using AutoMapper;
using Moq;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Account.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Test.Application
{
    public class PlaylistServiceTests
    {
        [Fact(DisplayName = "Criar Playlist com Sucesso")]
        [Trait("Categoria", "Playlist Service Mock Tests")]
        public async Task DeveCriarPlaylistComSucesso()
        {
            PlaylistInputDto dto = new PlaylistInputDto(null, "Rock",null);
            Mock<IPlaylistRepository> mockRepository = new Mock<IPlaylistRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            Playlist playlist = new Playlist()
            {
                Nome = "Rock"
            };

            PlaylistOutputDto dtoOutput = new PlaylistOutputDto(Guid.NewGuid(), "rock",null);

            mockMapper.Setup(x => x.Map<PlaylistOutputDto>(playlist)).Returns(dtoOutput);
            mockMapper.Setup(x => x.Map<Playlist>(dto)).Returns(playlist);

            mockRepository.Setup(x => x.Save(It.IsAny<Playlist>())).Returns(Task.FromResult(playlist));

            var service = new PlaylistService(mockRepository.Object, mockMapper.Object);
            var result = await service.Criar(dto);

            Assert.NotNull(result);

        }

        [Fact(DisplayName = "Atualizar Playlist com Sucesso")]
        [Trait("Categoria", "Playlist Service Mock Tests")]
        public async Task DeveAtualizarPlaylistComSucesso()
        {
            PlaylistInputDto dto = new PlaylistInputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "rock",null);
            Mock<IPlaylistRepository> mockRepository = new Mock<IPlaylistRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            Playlist playlist = new Playlist()
            {
                Nome = "Rock",
            };

            PlaylistOutputDto dtoOutput = new PlaylistOutputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Rock", null);

            mockMapper.Setup(x => x.Map<PlaylistOutputDto>(playlist)).Returns(dtoOutput);
            mockMapper.Setup(x => x.Map<Playlist>(dto)).Returns(playlist);

            mockRepository.Setup(x => x.Update(It.IsAny<Playlist>())).Returns(Task.FromResult(playlist));

            var service = new PlaylistService(mockRepository.Object, mockMapper.Object);
            var result = await service.Atualizar(dto);

            Assert.NotNull(result);

        }

        [Fact(DisplayName = "Deletar Playlist com Sucesso")]
        [Trait("Categoria", "Playlist Service Mock Tests")]
        public async Task DeveDeletarPlaylistComSucesso()
        {
            PlaylistInputDto dto = new PlaylistInputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Rock", null);
            Mock<IPlaylistRepository> mockRepository = new Mock<IPlaylistRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            Playlist playlist = new Playlist()
            {
                Nome = "Rock",
            };

            PlaylistOutputDto dtoOutput = new PlaylistOutputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "Rock", null);

            mockMapper.Setup(x => x.Map<PlaylistOutputDto>(playlist)).Returns(dtoOutput);
            mockMapper.Setup(x => x.Map<Playlist>(dto)).Returns(playlist);

            mockRepository.Setup(x => x.Delete(It.IsAny<Playlist>())).Returns(Task.FromResult(playlist));

            var service = new PlaylistService(mockRepository.Object, mockMapper.Object);
            var result = await service.Deletar(dto);

            Assert.NotNull(result);

        }
    }
}
