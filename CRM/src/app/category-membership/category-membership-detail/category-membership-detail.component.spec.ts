import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryMembershipDetailComponent } from './category-membership-detail.component';

describe('CategoryMembershipDetailComponent', () => {
  let component: CategoryMembershipDetailComponent;
  let fixture: ComponentFixture<CategoryMembershipDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryMembershipDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryMembershipDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
