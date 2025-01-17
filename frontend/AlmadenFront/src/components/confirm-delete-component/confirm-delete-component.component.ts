import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-confirm-delete-dialog',
  templateUrl: './confirm-delete-dialog.component.html',
  standalone: true,
})
export class ConfirmDeleteComponentComponent {
  constructor(public dialogRef: MatDialogRef<ConfirmDeleteComponentComponent>) {}

  onCancel(): void {
    this.dialogRef.close(false);
  }


  onConfirm(): void {
    this.dialogRef.close(true);
  }
}