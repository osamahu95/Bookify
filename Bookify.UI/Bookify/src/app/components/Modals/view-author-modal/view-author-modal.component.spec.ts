import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewAuthorModalComponent } from './view-author-modal.component';

describe('ViewAuthorModalComponent', () => {
  let component: ViewAuthorModalComponent;
  let fixture: ComponentFixture<ViewAuthorModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewAuthorModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewAuthorModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
