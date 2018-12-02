import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleListBookingFilterComponent } from './vehicle-list-booking-filter.component';

describe('VehicleListBookingFilterComponent', () => {
  let component: VehicleListBookingFilterComponent;
  let fixture: ComponentFixture<VehicleListBookingFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleListBookingFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleListBookingFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
