import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleBookingDetailsComponent } from './vehicle-booking-details.component';

describe('VehicleBookingDetailsComponent', () => {
  let component: VehicleBookingDetailsComponent;
  let fixture: ComponentFixture<VehicleBookingDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleBookingDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleBookingDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
