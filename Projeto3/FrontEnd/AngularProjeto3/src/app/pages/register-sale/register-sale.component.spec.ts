import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterSaleComponent } from './register-sale.component';

describe('RegisterSaleComponent', () => {
  let component: RegisterSaleComponent;
  let fixture: ComponentFixture<RegisterSaleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegisterSaleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterSaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
