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
    public class UsuarioServiceTests
    {
        [Fact(DisplayName = "Criar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public async Task DeveCriarUsuarioComSucesso()
        {
            UsuarioInputDto dto = new UsuarioInputDto(null,"isaias","i@g.com","12345");
            Mock<IUsuarioRepository> mockRepository = new Mock<IUsuarioRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            Usuario usuario = new Usuario()
            {
                Nome = "Lorem ipsum da usuario",
                Email = new Domain.Account.ValueObject.Email("ijunior@g.com"),
                Password = new Domain.Account.ValueObject.Password("1234")
            };

            UsuarioOutputDto dtoOutput = new UsuarioOutputDto(Guid.NewGuid(), "isaias", "i@g;cp,", "12345");

            mockMapper.Setup(x => x.Map<UsuarioOutputDto>(usuario)).Returns(dtoOutput);
            mockMapper.Setup(x => x.Map<Usuario>(dto)).Returns(usuario);

            mockRepository.Setup(x => x.Save(It.IsAny<Usuario>())).Returns(Task.FromResult(usuario));

            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);
            var result = await service.Criar(dto);

            Assert.NotNull(result);

        }

        [Fact(DisplayName = "Atualizar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public async Task DeveAtualizarUsuarioComSucesso()
        {
            UsuarioInputDto dto = new UsuarioInputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "isaias", "i@g.com", "12345");
            Mock<IUsuarioRepository> mockRepository = new Mock<IUsuarioRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            Usuario usuario = new Usuario()
            {
                Nome = "Lorem ipsum da usuario",
                Email = new Domain.Account.ValueObject.Email("ijunior@g.com"),
                Password = new Domain.Account.ValueObject.Password("1234")
            };

            UsuarioOutputDto dtoOutput = new UsuarioOutputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "isaias", "i@g.com", "12345");

            mockMapper.Setup(x => x.Map<UsuarioOutputDto>(usuario)).Returns(dtoOutput);
            mockMapper.Setup(x => x.Map<Usuario>(dto)).Returns(usuario);

            mockRepository.Setup(x => x.Update(It.IsAny<Usuario>())).Returns(Task.FromResult(usuario));

            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);
            var result = await service.Atualizar(dto);

            Assert.NotNull(result);

        }

        [Fact(DisplayName = "Deletar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public async Task DeveDeletarUsuarioComSucesso()
        {
            UsuarioInputDto dto = new UsuarioInputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "isaias", "i@g.com", "12345");
            Mock<IUsuarioRepository> mockRepository = new Mock<IUsuarioRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            Usuario usuario = new Usuario()
            {
                Nome = "Lorem ipsum da usuario",
                Email = new Domain.Account.ValueObject.Email("ijunior@g.com"),
                Password = new Domain.Account.ValueObject.Password("1234")
            };

            UsuarioOutputDto dtoOutput = new UsuarioOutputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "isaias", "i@g.com", "12345");

            mockMapper.Setup(x => x.Map<UsuarioOutputDto>(usuario)).Returns(dtoOutput);
            mockMapper.Setup(x => x.Map<Usuario>(dto)).Returns(usuario);

            mockRepository.Setup(x => x.Delete(It.IsAny<Usuario>())).Returns(Task.FromResult(usuario));

            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);
            var result = await service.Deletar(dto);

            Assert.NotNull(result);

        }

    }
}
