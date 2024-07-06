
namespace Domain.Models
{
    public class Album
    {
        private Album() { }
        internal Album(string title,  string description, Guid artistId)
        {
            AlbumId = Guid.NewGuid();
            Title = title;
            Description = description;
            ArtistId = artistId;
        }

        public Guid AlbumId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public Guid ArtistId { get; private set; }

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
