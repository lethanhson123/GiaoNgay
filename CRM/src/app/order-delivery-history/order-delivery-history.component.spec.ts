import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDeliveryHistoryComponent } from './order-delivery-history.component';

describe('OrderDeliveryHistoryComponent', () => {
  let component: OrderDeliveryHistoryComponent;
  let fixture: ComponentFixture<OrderDeliveryHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDeliveryHistoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDeliveryHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
