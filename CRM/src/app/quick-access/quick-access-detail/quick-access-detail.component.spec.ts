import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QuickAccessDetailComponent } from './quick-access-detail.component';

describe('QuickAccessDetailComponent', () => {
  let component: QuickAccessDetailComponent;
  let fixture: ComponentFixture<QuickAccessDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QuickAccessDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QuickAccessDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
