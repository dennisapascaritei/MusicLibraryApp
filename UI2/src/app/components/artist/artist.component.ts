import { Component, OnInit } from '@angular/core';
import { ArtistsService } from '../../services/artists.service';
import { Artist } from '../../models/artist';
@Component({
  selector: 'app-artist',
  standalone: true,
  imports: [],
  templateUrl: './artist.component.html',
  styleUrl: './artist.component.css'
})
export class ArtistComponent implements OnInit{
  message = ""
  artists: Artist[] = [];

  constructor(private artistsService: ArtistsService){}
  ngOnInit(): void {
    this.artistsService.getAllArtists().subscribe((data: any[]) => {
      this.artists = data;
      console.log(this.artists)
    })
  }
}
