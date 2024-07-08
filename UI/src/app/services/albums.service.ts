import { HttpClient, HttpParams } from '@angular/common/http';
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

  getAllAlbums(artistId?: string): Observable<Album[]> {
    let params = new HttpParams();
    if (artistId) {
      params = params.append('artistId', artistId);
    }

    return this.httpClient.get<Album[]>(`${environment.apiUrl}/${this.url}`, { params });
  }

  getAlbumById(id: any) {
    return this.httpClient.get<Album>(`${environment.apiUrl}/${this.url}/${id}`)
  }
  createAlbum(newAlbum: Album): Observable<Album>{
    return this.httpClient.post<Album>(`${environment.apiUrl}/${this.url}`, newAlbum)
  }

  updateAlbum(updateAlbum: Album): Observable<Album>{
    return this.httpClient.put<Album>(`${environment.apiUrl}/${this.url}`, updateAlbum)
  }

  deleteAlbum(albumId: any) {
    return this.httpClient.delete<Album>(`${environment.apiUrl}/${this.url}/${albumId}`)
  }
}
