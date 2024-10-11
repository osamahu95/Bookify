import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewBookshopModalComponent } from './view-bookshop-modal.component';

describe('ViewBookshopModalComponent', () => {
  let component: ViewBookshopModalComponent;
  let fixture: ComponentFixture<ViewBookshopModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewBookshopModalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewBookshopModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
