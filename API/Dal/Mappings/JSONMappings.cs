using AutoMapper;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Mappings
{
    internal class JSONMappings: Profile
    {
        public JSONMappings() {
            CreateMap<ArtistDto, Artist>();
            CreateMap<AlbumDto, Album>();
            CreateMap<SongDto, Song>();
        }

    }
}
