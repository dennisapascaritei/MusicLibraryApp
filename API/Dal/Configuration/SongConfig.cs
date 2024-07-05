
namespace Dal.Configuration
{
    internal class SongConfig : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(s => s.SongId);
        }
    }
}
