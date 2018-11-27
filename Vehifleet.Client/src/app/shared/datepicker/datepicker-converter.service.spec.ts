import { TestBed } from '@angular/core/testing';

import { DatepickerConverterService } from './datepicker-converter.service';

describe('DatepickerConverterService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DatepickerConverterService = TestBed.get(DatepickerConverterService);
    expect(service).toBeTruthy();
  });
});
