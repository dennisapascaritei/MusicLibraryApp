
namespace Domain.Models
{
    public class Song
    {
        public Song() { }
        internal Song(string title, TimeSpan length, Album album)
        {
            SongId = new Guid();
            Title = title;
            Length = length;
            AlbumId = album.AlbumId;
            Album = album;
        }

        public Guid SongId { get; private set; }
        public string Title { get; private set; }
        public TimeSpan Length { get; private set; } = TimeSpan.Zero;
        public Guid AlbumId { get; private set; }
        public Album Album { get; private set; }


        public static Song CreateSong(string title, TimeSpan length, Album album)
        {
            return new Song(title, length, album);
        }
    }
}
