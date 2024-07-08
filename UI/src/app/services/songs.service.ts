import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Song } from '../models/songs';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SongsService {

  url = 'Song'

  constructor(private httpClient: HttpClient) { }

  getAllSongs(): Observable<Song[]>{
    return this.httpClient.get<Song[]>(`${environment.apiUrl}/${this.url}`)
  }

  getSongById(id: any) {
    return this.httpClient.get<Song>(`${environment.apiUrl}/${this.url}/${id}`)
  }
  createSong(newSong: Song): Observable<Song>{
    return this.httpClient.post<Song>(`${environment.apiUrl}/${this.url}`, newSong)
  }
}
