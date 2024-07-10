import { Component } from '@angular/core';
import { SearchService } from '../../services/search.service';
import { SearchResult } from '../../models/searchResult';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  searchResults: SearchResult[] = [];

  constructor(private searchService: SearchService,
              private router: Router) {}

  search(searchItem: string): void {
    this.searchService.getSearchResult(searchItem).subscribe(
      (result) => {
        this.searchResults = result
      },
      error => {
        console.error('Error deleting song:', error);
      }
    );
  }

  clearSearchResults(): void {
    this.searchResults = [];
  }

  navigateToResult(res: any): void {
    let targetRoute: string;
    let songId: string;
  
    if (res.category === 'Artist') {
      targetRoute = `/artists/${res.result.artistId}`;
    } else {
      targetRoute = `/albums/${res.result.albumId}`;
    }

    if (res.category === 'Song') {
      songId = res.result.songId;
    }
  
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([targetRoute], { queryParams: { songId: songId } });
    });
  
    this.clearSearchResults();
  }
  
}
