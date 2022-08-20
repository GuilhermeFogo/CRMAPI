import { TestBed } from '@angular/core/testing';

import { LoginBlockService } from './login-block.service';

describe('LoginBlockService', () => {
  let service: LoginBlockService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LoginBlockService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
