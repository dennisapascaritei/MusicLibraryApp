using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Dal.Models;
using Domain.Models;
using Newtonsoft.Json;


namespace Dal.Seed
{
    public static class DataSeeder
    {
        public static (List<Artist>, List<Album>, List<Song>) LoadSeedData(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var artists = JsonConvert.DeserializeObject<List<Artist>>(json);

            var songList = new List<Song>();
            var albumList = new List<Album>();
            var artistList = new List<Artist>();

            foreach (var artist in artists)
            {
                var newArtist = Artist.CreateArtist(artist.Name);
                artistList.Add(newArtist);
                foreach (var album in artist.Albums)
                {
                    var newDescription = album.Description.Replace("\n\t", "");
                    var newAlbum = Album.CreateAlbum(album.Title, newDescription, newArtist.ArtistId);
                    albumList.Add(newAlbum);
                    foreach (var song in album.Songs)
                    {
                        var parts = song.Length.ToString().Split(':');

                        if (!int.TryParse(parts[0], out int minutes) || !int.TryParse(parts[1], out int seconds))
                        {
                            throw new ArgumentException("Invalid time format. Expected numeric values for minutes and seconds.");
                        }

                        var formatLength = new TimeSpan(0, minutes, seconds);
                        var newSong = Song.CreateSong(song.Title, formatLength, newAlbum.AlbumId);
                        songList.Add(newSong);
                    }
                }
            }

            return (artistList, albumList, songList);
        }
    }
}
