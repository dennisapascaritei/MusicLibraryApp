
namespace Dal.Configuration
{
    internal class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(a => a.AlbumId);
            builder.HasMany<Song>(a => a.Songs)
                .WithOne()
                .HasForeignKey(s => s.AlbumId);
        }
    }
}
