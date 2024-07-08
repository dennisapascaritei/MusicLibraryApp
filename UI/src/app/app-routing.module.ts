import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewArtistsComponent } from './components/view-artists/view-artists.component';
import { ViewEditArtistComponent } from './components/view-edit-artist/view-edit-artist.component';
import { ViewAlbumComponent } from './components/view-album/view-album.component';

const routes: Routes = [
  {path: "", component: ViewArtistsComponent},
  {path: "artists", component: ViewArtistsComponent},
  {path: "artists/:id", component: ViewEditArtistComponent},
  {path: "albums/:id", component: ViewAlbumComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule{}
