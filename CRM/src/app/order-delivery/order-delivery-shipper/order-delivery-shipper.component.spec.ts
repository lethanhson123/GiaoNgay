import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDeliveryShipperComponent } from './order-delivery-shipper.component';

describe('OrderDeliveryShipperComponent', () => {
  let component: OrderDeliveryShipperComponent;
  let fixture: ComponentFixture<OrderDeliveryShipperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDeliveryShipperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDeliveryShipperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
