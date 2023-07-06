import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDeliveryShopComponent } from './order-delivery-shop.component';

describe('OrderDeliveryShopComponent', () => {
  let component: OrderDeliveryShopComponent;
  let fixture: ComponentFixture<OrderDeliveryShopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDeliveryShopComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDeliveryShopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
