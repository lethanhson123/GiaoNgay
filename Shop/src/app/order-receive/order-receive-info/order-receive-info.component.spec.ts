import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderReceiveInfoComponent } from './order-receive-info.component';

describe('OrderReceiveInfoComponent', () => {
  let component: OrderReceiveInfoComponent;
  let fixture: ComponentFixture<OrderReceiveInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderReceiveInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderReceiveInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
