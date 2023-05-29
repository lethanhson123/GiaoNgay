import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDeliveryHistoryDetailComponent } from './order-delivery-history-detail.component';

describe('OrderDeliveryHistoryDetailComponent', () => {
  let component: OrderDeliveryHistoryDetailComponent;
  let fixture: ComponentFixture<OrderDeliveryHistoryDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDeliveryHistoryDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderDeliveryHistoryDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
