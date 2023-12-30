import { TestBed } from '@angular/core/testing';

import { AtasPageService } from './atas-page.service';

describe('AtasPageService', () => {
  let service: AtasPageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AtasPageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
