import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleSpecificationAddComponent } from './vehicle-specification-add.component';

describe('VehicleSpecificationAddComponent', () => {
  let component: VehicleSpecificationAddComponent;
  let fixture: ComponentFixture<VehicleSpecificationAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleSpecificationAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleSpecificationAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
