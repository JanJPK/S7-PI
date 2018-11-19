import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehicleListBookingComponent } from './vehicle-list-booking.component';

describe('VehicleListBookingComponent', () => {
  let component: VehicleListBookingComponent;
  let fixture: ComponentFixture<VehicleListBookingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehicleListBookingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehicleListBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
