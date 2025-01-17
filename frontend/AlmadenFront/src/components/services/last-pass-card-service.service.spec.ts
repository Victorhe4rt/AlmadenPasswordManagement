import { TestBed } from '@angular/core/testing';

import { LastPassCardServiceService } from './last-pass-card-service.service';

describe('LastPassCardServiceService', () => {
  let service: LastPassCardServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LastPassCardServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
