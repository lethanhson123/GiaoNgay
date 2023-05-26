import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderCallDetailComponent } from './order-call-detail.component';

describe('OrderCallDetailComponent', () => {
  let component: OrderCallDetailComponent;
  let fixture: ComponentFixture<OrderCallDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderCallDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OrderCallDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
