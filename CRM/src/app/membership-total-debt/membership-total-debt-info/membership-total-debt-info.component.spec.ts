import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembershipTotalDebtInfoComponent } from './membership-total-debt-info.component';

describe('MembershipTotalDebtInfoComponent', () => {
  let component: MembershipTotalDebtInfoComponent;
  let fixture: ComponentFixture<MembershipTotalDebtInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MembershipTotalDebtInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MembershipTotalDebtInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
