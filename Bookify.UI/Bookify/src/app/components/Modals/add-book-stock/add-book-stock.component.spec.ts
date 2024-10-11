import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBookStockComponent } from './add-book-stock.component';

describe('AddBookStockComponent', () => {
  let component: AddBookStockComponent;
  let fixture: ComponentFixture<AddBookStockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBookStockComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddBookStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
