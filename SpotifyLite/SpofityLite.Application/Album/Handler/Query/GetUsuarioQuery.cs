using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Handler.Query
{
    public class GetUsuarioQuery : IRequest<GetUsuarioQueryResponse>
    {
        public Guid IdUsuario { get; set; }

        public GetUsuarioQuery(Guid id)
        {
            IdUsuario = id;
        }

    }

    public class GetUsuarioQueryResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public GetUsuarioQueryResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
