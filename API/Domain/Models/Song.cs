
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Domain.Models
{
    public class Song
    {
        [JsonConstructor]
        internal Song(string title, TimeSpan length)
        {
            SongId = Guid.NewGuid();
            Title = title;
            Length = length;
        }

        public Song() { }
        internal Song(string title, TimeSpan length, Guid albumId)
        {
            SongId = Guid.NewGuid();
            Title = title;
            Length = length;
            AlbumId = albumId;
        }

        public Guid SongId { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("length")]
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
