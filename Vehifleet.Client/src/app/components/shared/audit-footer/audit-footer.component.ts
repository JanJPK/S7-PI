import { Component, OnInit, Input } from '@angular/core';
import { Auditable } from 'src/app/classes/base/auditable';

@Component({
  selector: 'app-audit-footer',
  templateUrl: './audit-footer.component.html',
  styleUrls: ['./audit-footer.component.scss']
})
export class AuditFooterComponent {
  @Input()
  auditable: Auditable;
  constructor() {}

  wasAdded(): boolean {
    return this.auditable.addedBy != null && this.auditable.addedBy != '';
  }

  wasModified(): boolean {
    return this.auditable.modifiedBy != null && this.auditable.modifiedBy != '';
  }
}
