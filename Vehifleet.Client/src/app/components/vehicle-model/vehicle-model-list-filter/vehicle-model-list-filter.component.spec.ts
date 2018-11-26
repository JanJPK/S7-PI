import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleModelListFilterComponent } from './vehicle-model-list-filter.component';

describe('VehicleModelListFilterComponent', () => {
  let component: VehicleModelListFilterComponent;
  let fixture: ComponentFixture<VehicleModelListFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleModelListFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleModelListFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
