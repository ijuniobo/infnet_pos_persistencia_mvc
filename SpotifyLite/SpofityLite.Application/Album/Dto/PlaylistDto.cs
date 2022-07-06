using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Dto
{
    public record PlaylistInputDto(
        [Required(ErrorMessage = "O nome é requerido!")] string Nome, List<MusicaInputDto> musicas);
    public record PlaylistOutputDto(Guid Id, string Nome, List<MusicaOutputDto> musicas);

}
