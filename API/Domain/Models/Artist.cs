namespace Domain.Models
{
    public class Artist
    {
        private Artist() { }
        internal Artist(string name)
        {
            ArtistId = new Guid();
            Name = name;
        }

        public Guid ArtistId { get; private set; }
        public string Name { get; private set; }
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
