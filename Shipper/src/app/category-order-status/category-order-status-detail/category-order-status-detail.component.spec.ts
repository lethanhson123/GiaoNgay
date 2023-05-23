import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryOrderStatusDetailComponent } from './category-order-status-detail.component';

describe('CategoryOrderStatusDetailComponent', () => {
  let component: CategoryOrderStatusDetailComponent;
  let fixture: ComponentFixture<CategoryOrderStatusDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryOrderStatusDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryOrderStatusDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
