import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryOrderDetailDetailComponent } from './category-order-detail-detail.component';

describe('CategoryOrderDetailDetailComponent', () => {
  let component: CategoryOrderDetailDetailComponent;
  let fixture: ComponentFixture<CategoryOrderDetailDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryOrderDetailDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryOrderDetailDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
