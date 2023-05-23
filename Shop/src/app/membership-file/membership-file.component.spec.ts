import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembershipFileComponent } from './membership-file.component';

describe('MembershipFileComponent', () => {
  let component: MembershipFileComponent;
  let fixture: ComponentFixture<MembershipFileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MembershipFileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MembershipFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
