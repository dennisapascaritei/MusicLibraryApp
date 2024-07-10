namespace Dal.Models
{
    public class AlbumDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<SongDto> Songs { get; set; }
    }
}