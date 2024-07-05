
namespace Dal
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArtistConfig());
            builder.ApplyConfiguration(new AlbumConfig());
            builder.ApplyConfiguration(new SongConfig());
        }
    }
}
