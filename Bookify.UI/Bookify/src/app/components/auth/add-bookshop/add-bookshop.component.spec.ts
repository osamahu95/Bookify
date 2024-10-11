import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBookshopComponent } from './add-bookshop.component';

describe('AddBookshopComponent', () => {
  let component: AddBookshopComponent;
  let fixture: ComponentFixture<AddBookshopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBookshopComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddBookshopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
