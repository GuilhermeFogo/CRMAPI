import { TestBed } from '@angular/core/testing';

import { OportunidadesService } from './oportunidades.service';

describe('OportunidadesService', () => {
  let service: OportunidadesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OportunidadesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
