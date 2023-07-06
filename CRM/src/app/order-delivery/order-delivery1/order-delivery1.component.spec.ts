import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDelivery1Component } from './order-delivery1.component';

describe('OrderDelivery1Component', () => {
  let component: OrderDelivery1Component;
  let fixture: ComponentFixture<OrderDelivery1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDelivery1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDelivery1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
