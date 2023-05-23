import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryOrderDetailComponent } from './category-order-detail.component';

describe('CategoryOrderDetailComponent', () => {
  let component: CategoryOrderDetailComponent;
  let fixture: ComponentFixture<CategoryOrderDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryOrderDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryOrderDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
