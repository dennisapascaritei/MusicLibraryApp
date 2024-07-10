
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Domain.Models
{
    public class Album
    {
        [JsonConstructor]
        internal Album(string title, string description, List<Song> songs)
        {
            AlbumId = Guid.NewGuid();
            Title = title;
            Description = description;
            Songs = songs ?? new List<Song>();
        }

        private Album() { }
        internal Album(string title,  string description, Guid artistId)
        {
            AlbumId = Guid.NewGuid();
            Title = title;
            Description = description;
            ArtistId = artistId;
        }

        public Guid AlbumId { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("description")]
        public string Description { get; private set; }

        public Guid ArtistId { get; private set; }
        [JsonProperty("songs")]
        public List<Song> Songs { get; private set; } = new List<Song>();


        public static Album CreateAlbum(string title, string description, Guid artistId)
        {
            return new Album(title, description, artistId);
        }

        public void UpdateAlbum(string title, string description, Guid artistId)
        {
            Title = title;
            Description = description;
            ArtistId = artistId;
        }
    }
}
