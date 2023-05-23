import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryOrderPaymentComponent } from './category-order-payment.component';

describe('CategoryOrderPaymentComponent', () => {
  let component: CategoryOrderPaymentComponent;
  let fixture: ComponentFixture<CategoryOrderPaymentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryOrderPaymentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryOrderPaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
