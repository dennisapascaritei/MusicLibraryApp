namespace Dal.Models
{
    public class SongDto
    {
        public string Title { get; set; }
        public TimeSpan Length { get; set; } = TimeSpan.Zero;
    }
}