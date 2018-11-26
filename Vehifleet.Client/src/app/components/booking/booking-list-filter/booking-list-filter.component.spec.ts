import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingListFilterComponent } from './booking-list-filter.component';

describe('BookingListFilterComponent', () => {
  let component: BookingListFilterComponent;
  let fixture: ComponentFixture<BookingListFilterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookingListFilterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookingListFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
