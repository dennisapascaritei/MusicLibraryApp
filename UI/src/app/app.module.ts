import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ViewArtistsComponent } from './components/view-artists/view-artists.component';
import { HttpClientModule } from '@angular/common/http';
import { ViewEditArtistComponent } from './components/view-edit-artist/view-edit-artist.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ViewAlbumComponent } from './components/view-album/view-album.component';

@NgModule({
  declarations: [
    AppComponent,
    ViewArtistsComponent,
    ViewEditArtistComponent,
    NavbarComponent,
    ViewAlbumComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
