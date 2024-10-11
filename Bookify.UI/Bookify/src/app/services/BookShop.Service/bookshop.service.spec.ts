import { TestBed } from '@angular/core/testing';

import { BookshopService } from './bookshop.service';

describe('BookshopService', () => {
  let service: BookshopService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookshopService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
