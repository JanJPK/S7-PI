import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingListPersonalComponent } from './booking-list-personal.component';

describe('BookingListPersonalComponent', () => {
  let component: BookingListPersonalComponent;
  let fixture: ComponentFixture<BookingListPersonalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookingListPersonalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookingListPersonalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
