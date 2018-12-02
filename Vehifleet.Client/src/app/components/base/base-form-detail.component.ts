import { Component, OnInit } from '@angular/core';
import { FormControl, AbstractControl, FormGroup } from '@angular/forms';
import { BaseFormComponent } from './base-form.component';

export abstract class BaseFormDetailComponent extends BaseFormComponent
  implements OnInit {
  constructor() {
    super();
  }

  ngOnInit() {
    this.get();
  }

  abstract get();

  abstract setUpForm();

  abstract onSubmit();

  abstract onDelete();

  isInvalid(formControlName: string): boolean {
    const formControl = this.form.get(formControlName);
    return !formControl.valid && (formControl.touched || formControl.dirty);
  }

  getControl(formControlName: string): AbstractControl {
    return this.form.get(formControlName);
  }
}
