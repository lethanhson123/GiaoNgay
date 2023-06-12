import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDeliveryDisplayColumnsComponent } from './order-delivery-display-columns.component';

describe('OrderDeliveryDisplayColumnsComponent', () => {
  let component: OrderDeliveryDisplayColumnsComponent;
  let fixture: ComponentFixture<OrderDeliveryDisplayColumnsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDeliveryDisplayColumnsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDeliveryDisplayColumnsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
