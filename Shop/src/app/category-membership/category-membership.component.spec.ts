import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryMembershipComponent } from './category-membership.component';

describe('CategoryMembershipComponent', () => {
  let component: CategoryMembershipComponent;
  let fixture: ComponentFixture<CategoryMembershipComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryMembershipComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryMembershipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
