import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditFooterComponent } from './audit-footer.component';

describe('AuditFooterComponent', () => {
  let component: AuditFooterComponent;
  let fixture: ComponentFixture<AuditFooterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuditFooterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuditFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
