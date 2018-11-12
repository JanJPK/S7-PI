import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleSpecificationComponent } from './vehicle-specification.component';

describe('VehicleSpecificationComponent', () => {
  let component: VehicleSpecificationComponent;
  let fixture: ComponentFixture<VehicleSpecificationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleSpecificationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleSpecificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
