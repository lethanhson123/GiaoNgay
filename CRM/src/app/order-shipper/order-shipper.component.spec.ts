import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderShipperComponent } from './order-shipper.component';

describe('OrderShipperComponent', () => {
  let component: OrderShipperComponent;
  let fixture: ComponentFixture<OrderShipperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderShipperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderShipperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
