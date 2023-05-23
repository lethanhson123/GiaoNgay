import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembershipFileDetailComponent } from './membership-file-detail.component';

describe('MembershipFileDetailComponent', () => {
  let component: MembershipFileDetailComponent;
  let fixture: ComponentFixture<MembershipFileDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MembershipFileDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MembershipFileDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
