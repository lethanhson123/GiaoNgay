import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDeliveryPaymentHistoryDetailComponent } from './order-delivery-payment-history-detail.component';

describe('OrderDeliveryPaymentHistoryDetailComponent', () => {
  let component: OrderDeliveryPaymentHistoryDetailComponent;
  let fixture: ComponentFixture<OrderDeliveryPaymentHistoryDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDeliveryPaymentHistoryDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDeliveryPaymentHistoryDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
