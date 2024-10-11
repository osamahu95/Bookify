import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddToBookShopComponent } from './add-to-book-shop.component';

describe('AddToBookShopComponent', () => {
  let component: AddToBookShopComponent;
  let fixture: ComponentFixture<AddToBookShopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddToBookShopComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddToBookShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
