import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleListBookingDetailsComponent } from './vehicle-list-booking-details.component';

describe('VehicleListBookingDetailsComponent', () => {
  let component: VehicleListBookingDetailsComponent;
  let fixture: ComponentFixture<VehicleListBookingDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleListBookingDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleListBookingDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
