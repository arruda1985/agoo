import { TestBed } from '@angular/core/testing';

import { AgooService } from './agoo.service';

describe('HouseService', () => {
  let service: AgooService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AgooService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
