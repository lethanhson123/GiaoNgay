import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembershipTotalDebtComponent } from './membership-total-debt.component';

describe('MembershipTotalDebtComponent', () => {
  let component: MembershipTotalDebtComponent;
  let fixture: ComponentFixture<MembershipTotalDebtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MembershipTotalDebtComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MembershipTotalDebtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
