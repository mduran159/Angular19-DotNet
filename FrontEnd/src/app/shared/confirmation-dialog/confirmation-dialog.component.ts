import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-confirmation-dialog',
  template: `
    <div class="dialog-container">
      <h2 class="dialog-title">Confirmation</h2>
      <p>{{ data.message }}</p>
      <div class="dialog-buttons">
        <button class="cancel-button" mat-button (click)="onCancel()">Cancel</button>
        <button class="confirm-button" mat-button (click)="onConfirm()">Confirm</button>
      </div>
    </div>
  `,
  styleUrl: './confirmation-dialog.component.css'
})
export class ConfirmationDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<ConfirmationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onCancel(): void {
    this.dialogRef.close(false);
  }

  onConfirm(): void {
    this.dialogRef.close(true);
  }
}