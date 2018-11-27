import { FormGroup, ValidationErrors, ValidatorFn } from '@angular/forms';

export const TimeSpanValidator: ValidatorFn = (
  control: FormGroup
): ValidationErrors | null => {
  const startDate = new Date(control.get('startDate').value);
  const endDate = new Date(control.get('endDate').value);
  return endDate < startDate ? { startDateBiggerThanEndDate: true } : null;
};
