import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleSpecificationEditComponent } from './vehicle-specification-edit.component';

describe('VehicleSpecificationEditComponent', () => {
  let component: VehicleSpecificationEditComponent;
  let fixture: ComponentFixture<VehicleSpecificationEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleSpecificationEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleSpecificationEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
