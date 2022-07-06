using AutoMapper;
using Moq;
using SpofityLite.Application.Album.Dto;
using SpofityLite.Application.Album.Service;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Test.Application
{
    public class BandaServiceTests
    {

        [Fact(DisplayName = "Criar Banda com Sucesso")]
        [Trait("Categoria", "Banda Service Mock Tests")]
        public async Task DeveCriarBandaComSucesso()
        {
            BandaInputDto dto = new BandaInputDto(null, "XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");
            Mock<IBandaRepository> mockRepository = new Mock<IBandaRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            Banda banda = new Banda()
            {
                Descricao = "Lorem ipsum da banda",
                Foto = "Lorem ipsum foto",
                Nome = "Xpto"
            };

            BandaOutputDto dtoOutput = new BandaOutputDto(Guid.NewGuid(), "XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");

            mockMapper.Setup(x => x.Map<BandaOutputDto>(banda)).Returns(dtoOutput);
            mockMapper.Setup(x => x.Map<Banda>(dto)).Returns(banda);

            mockRepository.Setup(x => x.Save(It.IsAny<Banda>())).Returns(Task.FromResult(banda));

            var service = new BandaService(mockRepository.Object, mockMapper.Object);
            var result = await service.Criar(dto);

            Assert.NotNull(result);

        }

        [Fact(DisplayName = "Atualizar Banda com Sucesso")]
        [Trait("Categoria", "Banda Service Mock Tests")]
        public async Task DeveAtualizarBandaComSucesso()
        {
            BandaInputDto dto = new BandaInputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");
            Mock<IBandaRepository> mockRepository = new Mock<IBandaRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            Banda banda = new Banda()
            {
                Descricao = "Lorem ipsum da banda",
                Foto = "Lorem ipsum foto",
                Nome = "Xpto"
            };

            BandaOutputDto dtoOutput = new BandaOutputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");

            mockMapper.Setup(x => x.Map<BandaOutputDto>(banda)).Returns(dtoOutput);
            mockMapper.Setup(x => x.Map<Banda>(dto)).Returns(banda);

            mockRepository.Setup(x => x.Update(It.IsAny<Banda>())).Returns(Task.FromResult(banda));

            var service = new BandaService(mockRepository.Object, mockMapper.Object);
            var result = await service.Atualizar(dto);

            Assert.NotNull(result);

        }

        [Fact(DisplayName = "Deletar Banda com Sucesso")]
        [Trait("Categoria", "Banda Service Mock Tests")]
        public async Task DeveDeletarBandaComSucesso()
        {
            BandaInputDto dto = new BandaInputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");
            Mock<IBandaRepository> mockRepository = new Mock<IBandaRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            Banda banda = new Banda()
            {
                Descricao = "Lorem ipsum da banda",
                Foto = "Lorem ipsum foto",
                Nome = "Xpto"
            };

            BandaOutputDto dtoOutput = new BandaOutputDto(new Guid("F9168C5E-CEB2-4faa-B6BF-329BF39FA1E4"), "XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");

            mockMapper.Setup(x => x.Map<BandaOutputDto>(banda)).Returns(dtoOutput);
            mockMapper.Setup(x => x.Map<Banda>(dto)).Returns(banda);

            mockRepository.Setup(x => x.Delete(It.IsAny<Banda>())).Returns(Task.FromResult(banda));

            var service = new BandaService(mockRepository.Object, mockMapper.Object);
            var result = await service.Deletar(dto);

            Assert.NotNull(result);

        }

    }
}
