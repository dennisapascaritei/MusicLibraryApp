using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Domain.Models
{
    public class Artist
    {
        [JsonConstructor]
        internal Artist(string name, List<Album> albums)
        {
            ArtistId = Guid.NewGuid();
            Name = name;
            Albums = albums ?? new List<Album>();
        }

        private Artist() { }
        internal Artist(string name)
        {
            ArtistId = Guid.NewGuid();
            Name = name;
        }

        public Guid ArtistId { get; private set; }
        [JsonProperty("name")]
        public string Name { get; private set; }
        [JsonProperty("albums")]
        public List<Album> Albums { get; private set; } = new List<Album>();


        public static Artist CreateArtist(string name)
        {
            return new Artist(name);
        }

        public void UpdateArtist(string name) { 
            Name = name;
        }
    }
}
