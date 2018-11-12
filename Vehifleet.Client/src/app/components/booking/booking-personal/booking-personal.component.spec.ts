import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingPersonalComponent } from './booking-personal.component';

describe('BookingPersonalComponent', () => {
  let component: BookingPersonalComponent;
  let fixture: ComponentFixture<BookingPersonalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookingPersonalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookingPersonalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
