import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleBookingFilterComponent } from './vehicle-booking-filter.component';

describe('VehicleBookingFilterComponent', () => {
  let component: VehicleBookingFilterComponent;
  let fixture: ComponentFixture<VehicleBookingFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleBookingFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleBookingFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
