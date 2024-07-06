
namespace Domain.Models
{
    public class Song
    {
        public Song() { }
        internal Song(string title, TimeSpan length, Guid albumId)
        {
            SongId = Guid.NewGuid();
            Title = title;
            Length = length;
            AlbumId = albumId;
        }

        public Guid SongId { get; private set; }
        public string Title { get; private set; }
        public TimeSpan Length { get; private set; } = TimeSpan.Zero;
        public Guid AlbumId { get; private set; }



        public static Song CreateSong(string title, TimeSpan length, Guid albumId)
        {
            return new Song(title, length, albumId);
        }

        public void UpdateSong(Song song)
        {
            Title = song.Title;
            Length = song.Length;
            AlbumId = song.AlbumId;
        }
    }
}
