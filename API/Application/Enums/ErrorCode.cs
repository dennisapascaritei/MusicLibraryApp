using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enums
{
    public enum ErrorCode
    {
        NotFound = 404,
        ServerError = 500,

        ArtistCreateNotPossible = 300,
        ArtistUpdateNotPossible = 301,
        ArtistDeleteNotPossible = 302,

        AlbumCreateNotPossible = 310,
        AlbumUpdateNotPossible = 311,
        AlbumDeleteNotPossible = 312,

        SongCreateNotPossible = 320,
        SongUpdateNotPossible = 321,
        SongDeleteNotPossible = 323,

        UnknownError = 999
    }
}
