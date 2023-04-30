import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryOrderStatusComponent } from './category-order-status.component';

describe('CategoryOrderStatusComponent', () => {
  let component: CategoryOrderStatusComponent;
  let fixture: ComponentFixture<CategoryOrderStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryOrderStatusComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryOrderStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
