import { Component, OnInit } from '@angular/core';
import { Artist } from '../../models/artist';
import { ArtistsService } from '../../services/artists.service';

@Component({
  selector: 'app-view-artists',
  templateUrl: './view-artists.component.html',
  styleUrl: './view-artists.component.css'
})
export class ViewArtistsComponent implements OnInit{
    artists: Artist[] = [];
    newArtist: Artist = new Artist();
    showAddArtistForm = false;
  
    constructor(private artistsService: ArtistsService){}
    ngOnInit(): void {
      this.loadArtists();
    }

    loadArtists() {
      this.artistsService.getAllArtists().subscribe((data: Artist[]) => {
        this.artists = data;
      });
    }

    toggleAddArtistForm() {
      this.showAddArtistForm = !this.showAddArtistForm;
    }

    addArtist(newArtist: Artist) {
      this.artistsService.createArtist(newArtist).subscribe(() => {
        this.loadArtists();
        this.newArtist = new Artist()
        this.showAddArtistForm = false;
      }, error => {
        console.error('Error adding artist:', error);
      });
    }

    deleteArtist(artist: Artist): void {
      this.artistsService.deleteArtist(artist.artistId).subscribe(
          () => {
              console.log('Artist deleted successfully');
              this.loadArtists();
          },
          (error) => {
              console.error('Error deleting artist:', error);
          }
      );
  }
  }
