import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { ArtistComponent } from './components/artist/artist.component';

export const routes: Routes = [
    {path: "artist", component: ArtistComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}
