import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewEditArtistComponent } from './view-edit-artist.component';

describe('ViewEditArtistComponent', () => {
  let component: ViewEditArtistComponent;
  let fixture: ComponentFixture<ViewEditArtistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ViewEditArtistComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ViewEditArtistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
