import { Injectable } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmModalComponent } from '../components/modal/confirm-modal/confirm-modal.component';

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  constructor(private modal: NgbModal) {}

  showConfirmationModal(title: string, header: string): Promise<any> {
    console.log('submit clicked');
    const modal = this.modal.open(ConfirmModalComponent);
    modal.componentInstance.title = title; // maintenance deletion
    modal.componentInstance.header = header; //'Are you sure you want to delete this maintenance?'
    modal.componentInstance.text = 'This operation cannot be undone.';
    return modal.result;
  }
}
