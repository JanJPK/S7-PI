import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleManagementEditComponent } from './vehicle-management-edit.component';

describe('VehicleManagementEditComponent', () => {
  let component: VehicleManagementEditComponent;
  let fixture: ComponentFixture<VehicleManagementEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleManagementEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleManagementEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
