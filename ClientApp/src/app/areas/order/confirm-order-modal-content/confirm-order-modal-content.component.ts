import { Component, OnInit, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

export interface DialogData {
  processOrder: boolean;
}

@Component({
  selector: 'app-confirm-order-modal-content',
  templateUrl: './confirm-order-modal-content.component.html',
  styleUrls: ['./confirm-order-modal-content.component.scss']
})
export class ConfirmOrderModalContentComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<ConfirmOrderModalContentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) { }

  ngOnInit(): void {
  }

}
