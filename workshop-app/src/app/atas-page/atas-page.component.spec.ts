import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AtasPageComponent } from './atas-page.component';

describe('AtasPageComponent', () => {
  let component: AtasPageComponent;
  let fixture: ComponentFixture<AtasPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AtasPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AtasPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
