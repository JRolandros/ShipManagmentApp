import { TestBed } from '@angular/core/testing';

import { ShipManagementService } from './ship-management.service';

describe('ShipManagementService', () => {
  let service: ShipManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShipManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
