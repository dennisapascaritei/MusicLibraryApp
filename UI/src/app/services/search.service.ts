import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SearchResult } from '../models/searchResult';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  url = 'Search'

  constructor(private httpClient: HttpClient) { }

  getSearchResult(searchItem: string): Observable<SearchResult[]>{
    return this.httpClient.get<SearchResult[]>(`${environment.apiUrl}/${this.url}/${searchItem}`)
  }
}
