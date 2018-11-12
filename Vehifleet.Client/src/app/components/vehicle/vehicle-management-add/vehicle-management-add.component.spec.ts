import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleManagementAddComponent } from './vehicle-management-add.component';

describe('VehicleManagementAddComponent', () => {
  let component: VehicleManagementAddComponent;
  let fixture: ComponentFixture<VehicleManagementAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleManagementAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleManagementAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
