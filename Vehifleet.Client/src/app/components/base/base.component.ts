import { Component, OnInit } from '@angular/core';
import { FormControl, AbstractControl, FormGroup } from '@angular/forms';

export abstract class BaseComponent implements OnInit {
  abstract form: FormGroup;

  constructor() {}

  ngOnInit() {
    this.get();
  }

  abstract get();

  abstract setUpForm();

  abstract onSubmit();

  isInvalid(formControlName: string): boolean {
    const formControl = this.form.get(formControlName);
    return !formControl.valid && (formControl.touched || formControl.dirty);
  }

  getControl(formControlName: string): AbstractControl {
    return this.form.get(formControlName);
  }
}
