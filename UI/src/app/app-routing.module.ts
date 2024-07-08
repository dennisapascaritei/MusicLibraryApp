import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewArtistsComponent } from './components/view-artists/view-artists.component';
import { ViewEditArtistComponent } from './components/view-edit-artist/view-edit-artist.component';

const routes: Routes = [
  {path: "", component: ViewArtistsComponent},
  {path: "artists", component: ViewArtistsComponent},
  {path: "artists/:id", component: ViewEditArtistComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule{}
