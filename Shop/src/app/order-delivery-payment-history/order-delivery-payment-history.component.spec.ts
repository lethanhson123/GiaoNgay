import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDeliveryPaymentHistoryComponent } from './order-delivery-payment-history.component';

describe('OrderDeliveryPaymentHistoryComponent', () => {
  let component: OrderDeliveryPaymentHistoryComponent;
  let fixture: ComponentFixture<OrderDeliveryPaymentHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDeliveryPaymentHistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDeliveryPaymentHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
