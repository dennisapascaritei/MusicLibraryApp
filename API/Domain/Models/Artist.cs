namespace Domain.Models
{
    public class Artist
    {
        private Artist() { }
        internal Artist(string name, List<Album> albums)
        {
            ArtistId = new Guid();
            Name = name;
            Albums = albums;
        }

        public Guid ArtistId { get; private set; }
        public string Name { get; private set; }
        public List<Album> Albums { get; private set; }


        public static Artist CreateArtist(string name, List<Album> albums)
        {
            return new Artist(name, albums);
        }
    }
}
