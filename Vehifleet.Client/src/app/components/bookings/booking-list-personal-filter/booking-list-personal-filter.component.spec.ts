import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingListPersonalFilterComponent } from './booking-list-personal-filter.component';

describe('BookingListPersonalFilterComponent', () => {
  let component: BookingListPersonalFilterComponent;
  let fixture: ComponentFixture<BookingListPersonalFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookingListPersonalFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookingListPersonalFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
