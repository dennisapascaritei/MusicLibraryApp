import { Component } from '@angular/core';
import { Artist } from '../../models/artist';
import { ArtistsService } from '../../services/artists.service';
import { ActivatedRoute } from '@angular/router';
import { AlbumsService } from '../../services/albums.service';
import { Album } from '../../models/album';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-edit-artist',
  templateUrl: './view-edit-artist.component.html',
  styleUrl: './view-edit-artist.component.css'
})
export class ViewEditArtistComponent {

  artist: Artist = new Artist();
  albums: Album[] = [];

  newAlbum: Album = new Album();

  constructor(private artistService: ArtistsService,
              private albumsService: AlbumsService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.getArtist();
    this.getAlbums();
    };

  getArtist(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));
    this.artistService.getArtistById(id)
      .subscribe(art => this.artist = art);
  }
  getAlbums(): void {
    this.albumsService.getAllAlbums().subscribe((data: any[]) => {
      this.albums = data;
      console.log(this.albums)
    })
  }

  createAlbum(album: Album, artistId: string) {
    album.artistId = artistId
    this.albumsService.createAlbum(album).subscribe(
      (data) => {
        this.albums.push(data)
        this.newAlbum.title = ""
        this.newAlbum.description = ""
      }
    );
  }

  updateArtist(updatedArtist: Artist): void {
    this.artistService.updateArtist(updatedArtist).subscribe(
      (data) => {
        this.artist = data
        console.log('Artist Updated', data)
      }
    )
  }
    
  deleteAlbum(albumId:string): void {
    this.albumsService.deleteAlbum(albumId).subscribe(
      () => {
        // Album deleted successfully, update albums array
        this.albums = this.albums.filter((album) => album.albumId !== albumId);
      },
      (error) => {
        console.error('Error deleting album:', error);
      }
    );
  }

  goBack(): void {
    this.router.navigate(['/artists']); // Navigate to the artists list page
  }
}
