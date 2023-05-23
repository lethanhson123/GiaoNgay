import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderShipperInfoComponent } from './order-shipper-info.component';

describe('OrderShipperInfoComponent', () => {
  let component: OrderShipperInfoComponent;
  let fixture: ComponentFixture<OrderShipperInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderShipperInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderShipperInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
