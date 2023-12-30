import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardsPageComponent } from './dashboards-page.component';

describe('DashboardsPageComponent', () => {
  let component: DashboardsPageComponent;
  let fixture: ComponentFixture<DashboardsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DashboardsPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DashboardsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
