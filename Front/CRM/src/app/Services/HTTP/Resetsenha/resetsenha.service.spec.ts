import { TestBed } from '@angular/core/testing';

import { ResetsenhaService } from './resetsenha.service';

describe('ResetsenhaService', () => {
  let service: ResetsenhaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ResetsenhaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
