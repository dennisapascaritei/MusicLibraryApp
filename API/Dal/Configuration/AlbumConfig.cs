
namespace Dal.Configuration
{
    internal class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(a => a.AlbumId);
            builder.HasMany<Song>(a => a.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.SongId);
        }
    }
}
