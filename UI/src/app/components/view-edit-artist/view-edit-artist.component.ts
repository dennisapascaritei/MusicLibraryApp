import { Component } from '@angular/core';
import { Artist } from '../../models/artist';
import { ArtistsService } from '../../services/artists.service';
import { ActivatedRoute } from '@angular/router';
import { AlbumsService } from '../../services/albums.service';
import { Album } from '../../models/album';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-view-edit-artist',
  templateUrl: './view-edit-artist.component.html',
  styleUrl: './view-edit-artist.component.css'
})
export class ViewEditArtistComponent {

  artist: Artist = new Artist();
  albums: Album[] = [];
  newAlbum: Album = new Album();

  showArtistEditMode = false;

  constructor(private artistService: ArtistsService,
              private albumsService: AlbumsService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.getArtist();
    };

    // Artist methods
    getArtist(): void {
      const id = String(this.route.snapshot.paramMap.get('id'));
      this.artistService.getArtistById(id).subscribe(
        art => {
          this.artist = art
        },
        error => {
          console.error('Error creating song:', error);
        }
      );
    }

    updateArtist(updatedArtist: Artist): void {
      this.artistService.updateArtist(updatedArtist).subscribe(
        (data) => {
          this.artist = data;
          this.toggleArtistEditMode();
        },
        error => {
          console.error('Error creating song:', error);
        }
      )
    }

    deleteArtist(artistId:string): void {
      this.artistService.deleteArtist(artistId).subscribe(
        () => {
          this.router.navigate(['/artists']);
        },
        (error) => {
          console.error('Error deleting album:', error);
        }
      );
    }

    // Album methods
    createAlbum(album: Album, artistId: string, form: NgForm) {
      album.artistId = artistId
      this.albumsService.createAlbum(album).subscribe(
        (data) => {
          this.getArtist()
          form.resetForm();
        },
        error => {
          console.error('Error creating song:', error);
        }
      );
    }

    deleteAlbum(albumId:string): void {
      this.albumsService.deleteAlbum(albumId).subscribe(
        () => {
          this.getArtist()
        },
        (error) => {
          console.error('Error deleting album:', error);
        }
      );
    }

    // Functional methods
    goBack(): void {
      this.router.navigate(['/artists']);
    }

    toggleArtistEditMode() {
      this.showArtistEditMode = !this.showArtistEditMode
    }
}
