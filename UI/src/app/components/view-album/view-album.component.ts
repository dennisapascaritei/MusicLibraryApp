import { Component } from '@angular/core';
import { Album } from '../../models/album';
import { Song } from '../../models/songs';
import { ActivatedRoute, Router } from '@angular/router';
import { AlbumsService } from '../../services/albums.service';
import { SongsService } from '../../services/songs.service';
import { NgForm, NgModel } from '@angular/forms';



@Component({
  selector: 'app-view-album',
  templateUrl: './view-album.component.html',
  styleUrl: './view-album.component.css'
})
export class ViewAlbumComponent {

  album: Album = new Album();
  songs: Song[] = [];
  newSong: Song = new Song ();

  showSongEditMode: boolean = false;
  showAlbumEditMode: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private albumsService: AlbumsService,
    private songsService: SongsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getAlbum();
  };


  // Album methods
  getAlbum(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));
    this.albumsService.getAlbumById(id)
      .subscribe(art => this.album = art);
  }

  updateAlbum(updatedAlbum: Album): void {
    this.albumsService.updateAlbum(updatedAlbum).subscribe(
      (data) => {
        this.album = data
        this.getAlbum()
        this.toggleAlbumsEditMode()
      },
      error => {
        console.error('Error creating song:', error);
      }
    )
  }

  deleteAlbum(albumId: string): void {
    this.albumsService.deleteAlbum(albumId).subscribe(
      () => {
        this.router.navigate([`/artists/${this.album.artistId}`]);
      },
      error => {
        console.error('Error deleting album:', error);
      }
    );
  }


  // Song methods
  createSong(newSong: Song, albumId: string, form: NgForm): void {
    newSong.albumId = albumId; 
    this.songsService.createSong(newSong).subscribe(
      () => {
        this.newSong = new Song()
        this.getAlbum();
        form.resetForm()
      },
      error => {
        console.error('Error creating song:', error);
      }
    );
  }

  updateSong(updatedSong: Song): void {
    this.songsService.updateSong(updatedSong).subscribe(
      () => {
        this.getAlbum();
        this.toggleSongsEditMode();
      },
      error => {
        console.error('Error creating song:', error);
      }
    )
  }

  deleteSong(songId: string): void {
    this.songsService.deleteSong(songId).subscribe(
      () => {
        this.getAlbum();
      },
      error => {
        console.error('Error deleting song:', error);
      }
    );
  }

  //Functional methods
  goBack(): void {
    this.router.navigate([`/artists/${this.album.artistId}`]);
  }

  toggleSongsEditMode() {
    this.showSongEditMode = !this.showSongEditMode
  }
  
  toggleAlbumsEditMode() {
    this.showAlbumEditMode = !this.showAlbumEditMode
  }
}