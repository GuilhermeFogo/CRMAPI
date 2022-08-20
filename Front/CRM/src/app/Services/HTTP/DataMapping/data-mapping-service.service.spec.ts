import { TestBed } from '@angular/core/testing';

import { DataMappingServiceService } from './data-mapping-service.service';

describe('DataMappingServiceService', () => {
  let service: DataMappingServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DataMappingServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
