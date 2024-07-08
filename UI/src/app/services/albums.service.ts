import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Album } from '../models/album';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AlbumsService {

  url = 'Album'

  constructor(private httpClient: HttpClient) { }

  getAllAlbums(): Observable<Album[]>{
    return this.httpClient.get<Album[]>(`${environment.apiUrl}/${this.url}`)
  }

  getAlbumById(id: any) {
    return this.httpClient.get<Album>(`${environment.apiUrl}/${this.url}/${id}`)
  }
  createAlbum(newAlbum: Album): Observable<Album>{
    return this.httpClient.post<Album>(`${environment.apiUrl}/${this.url}`, newAlbum)
  }

  updateAlbum(updateAlbum: Album): Observable<Album>{
    return this.httpClient.post<Album>(`${environment.apiUrl}/${this.url}`, updateAlbum)
  }

  deleteAlbum(id: any) {
    return this.httpClient.delete<Album>(`${environment.apiUrl}/${this.url}/${id}`)
  }
}
