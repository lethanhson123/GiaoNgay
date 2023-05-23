import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderShipperLiveComponent } from './order-shipper-live.component';

describe('OrderShipperLiveComponent', () => {
  let component: OrderShipperLiveComponent;
  let fixture: ComponentFixture<OrderShipperLiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderShipperLiveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderShipperLiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
