import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Ship } from 'src/app/models/ship.model';

@Component({
  selector: 'ship-app-delete-ship-dialog',
  templateUrl: './delete-ship-dialog.component.html',
  styleUrls: ['./delete-ship-dialog.component.scss']
})
export class DeleteShipDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<DeleteShipDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  onCancel(): void {
    this.dialogRef.close(false);
  }

}
