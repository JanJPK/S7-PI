import { Injectable } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmModalComponent } from './confirm-modal/confirm-modal.component';
import { InfoModalComponent } from './info-modal/info-modal.component';
import { ErrorModalComponent } from './error-modal/error-modal.component';
import { SuccessModalComponent } from './success-modal/success-modal.component';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  constructor(private modal: NgbModal) {}

  showSuccessModal(text: string) {
    const modal = this.modal.open(SuccessModalComponent);
    modal.componentInstance.text = text;
  }

  showInfoModal(text: string) {
    const modal = this.modal.open(InfoModalComponent);
    modal.componentInstance.text = text;
  }

  showErrorModal(text: string) {
    const modal = this.modal.open(ErrorModalComponent);
    modal.componentInstance.text = text;
  }

  showConfirmModal(text: string): Promise<any> {
    const modal = this.modal.open(ConfirmModalComponent);
    modal.componentInstance.text = text;
    return modal.result;
  }
}
