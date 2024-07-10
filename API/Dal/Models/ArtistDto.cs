using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class ArtistDto
    {
        public string Name { get; set; }
        public List<AlbumDto> Albums { get; set; } = new List<AlbumDto>();
    }
}
