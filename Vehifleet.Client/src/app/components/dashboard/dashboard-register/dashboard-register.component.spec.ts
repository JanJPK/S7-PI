import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardRegisterComponent } from './dashboard-register.component';

describe('DashboardRegisterComponent', () => {
  let component: DashboardRegisterComponent;
  let fixture: ComponentFixture<DashboardRegisterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashboardRegisterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardRegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
