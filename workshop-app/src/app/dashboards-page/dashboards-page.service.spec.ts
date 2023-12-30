import { TestBed } from '@angular/core/testing';

import { DashboardsPageService } from './dashboards-page.service';

describe('DashboardsPageService', () => {
  let service: DashboardsPageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DashboardsPageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
