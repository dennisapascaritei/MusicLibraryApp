﻿
namespace Dal.Configuration
{
    internal class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(ar => ar.ArtistId);
            builder.HasMany<Album>(ar => ar.Albums)
                .WithOne(al => al.Artist)
                .HasForeignKey(al => al.AlbumId);
        }
    }
}