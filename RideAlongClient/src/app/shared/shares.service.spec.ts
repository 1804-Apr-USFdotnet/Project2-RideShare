import { TestBed, inject } from '@angular/core/testing';

import { SharesService } from './shares.service';

describe('SharesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SharesService]
    });
  });

  it('should be created', inject([SharesService], (service: SharesService) => {
    expect(service).toBeTruthy();
  }));
});
