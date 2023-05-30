import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDeliveryDesktopComponent } from './order-delivery-desktop.component';

describe('OrderDeliveryDesktopComponent', () => {
  let component: OrderDeliveryDesktopComponent;
  let fixture: ComponentFixture<OrderDeliveryDesktopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDeliveryDesktopComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDeliveryDesktopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
