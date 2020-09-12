import { TestBed } from '@angular/core/testing';

import { OasService } from './oas.service';

describe('OasService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: OasService = TestBed.get(OasService);
    expect(service).toBeTruthy();
  });
});
