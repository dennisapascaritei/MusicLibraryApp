import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Artist } from '../models/artist';

@Injectable({
  providedIn: 'root'
})
export class ArtistsService {
  url = 'Artist'

  constructor(private httpClient: HttpClient) { }

  getAllArtists(): Observable<Artist[]>{
    return this.httpClient.get<Artist[]>(`${environment.apiUrl}/${this.url}`)
  }

  getArtistById(id: any) {
    return this.httpClient.get<Artist>(`${environment.apiUrl}/${this.url}/${id}`)
  }
  createArtist(newArtist: Artist): Observable<Artist>{
    return this.httpClient.post<Artist>(`${environment.apiUrl}/${this.url}`, newArtist)
  }

  updateArtist(updateArtist: Artist): Observable<Artist>{
    return this.httpClient.put<Artist>(`${environment.apiUrl}/${this.url}`, updateArtist)
  }

  deleteArtist(artistId: string): Observable<void> {
    return this.httpClient.delete<void>(`${environment.apiUrl}/${this.url}/${artistId}`)
  }


}
