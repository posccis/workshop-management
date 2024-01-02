import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PizzaplotComponent } from './pizzaplot.component';

describe('PizzaplotComponent', () => {
  let component: PizzaplotComponent;
  let fixture: ComponentFixture<PizzaplotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PizzaplotComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PizzaplotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
