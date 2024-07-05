
namespace Domain.Models
{
    public class Album
    {
        private Album() { }
        internal Album(string title, List<Song> songs, string description, Guid artistId,  Artist artist)
        {
            AlbumId = new Guid();
            Title = title;
            Songs = songs;
            Description = description;
            ArtistId = artistId;
            Artist = artist;
        }

        public Guid AlbumId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public Guid ArtistId { get; private set; }
        public Artist Artist { get; private set; }

        public List<Song> Songs { get; private set; }


        public static Album CreateAlbum(string title, List<Song> songs, string description, Guid artistId, Artist artist)
        {
            return new Album(title, songs, description, artistId, artist);
        }
    }
}
