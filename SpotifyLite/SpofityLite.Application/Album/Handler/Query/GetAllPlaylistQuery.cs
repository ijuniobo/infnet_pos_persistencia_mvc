﻿using MediatR;
using SpofityLite.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpofityLite.Application.Album.Handler.Query
{
    public class GetAllPlaylistQuery : IRequest<GetAllPlaylistQueryResponse>
    {

    }

    public class GetAllPlaylistQueryResponse
    {
        public IList<PlaylistOutputDto> Playlists { get; set; }

        public GetAllPlaylistQueryResponse(IList<PlaylistOutputDto> playlists)
        {
            Playlists = playlists;
        }
    }
}
