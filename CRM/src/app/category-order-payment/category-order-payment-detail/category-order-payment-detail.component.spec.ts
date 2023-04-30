import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryOrderPaymentDetailComponent } from './category-order-payment-detail.component';

describe('CategoryOrderPaymentDetailComponent', () => {
  let component: CategoryOrderPaymentDetailComponent;
  let fixture: ComponentFixture<CategoryOrderPaymentDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryOrderPaymentDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryOrderPaymentDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
