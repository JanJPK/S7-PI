import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleListFilterComponent } from './vehicle-list-filter.component';

describe('VehicleListFilterComponent', () => {
  let component: VehicleListFilterComponent;
  let fixture: ComponentFixture<VehicleListFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleListFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleListFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
