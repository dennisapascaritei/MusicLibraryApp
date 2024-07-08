
namespace API.Mappings
{
    public class Mappings : Profile
    {
        public Mappings() {
            CreateMap<Artist, ArtistResponse>();
            CreateMap<Album, AlbumResponse>();
            CreateMap<Song, SongResponse>();
        }
    }
}
