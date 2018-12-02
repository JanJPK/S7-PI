import { Component, OnInit } from '@angular/core';
import { FormControl, AbstractControl, FormGroup } from '@angular/forms';

export abstract class BaseFormComponent {
  abstract form: FormGroup;

  constructor() {}

  isInvalid(formControlName: string): boolean {
    const formControl = this.form.get(formControlName);
    return !formControl.valid && (formControl.touched || formControl.dirty);
  }

  getControl(formControlName: string): AbstractControl {
    return this.form.get(formControlName);
  }
}
