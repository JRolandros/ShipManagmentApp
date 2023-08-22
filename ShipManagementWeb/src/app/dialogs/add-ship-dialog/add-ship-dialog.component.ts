import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Ship } from 'src/app/models/ship.model';

@Component({
  selector: 'ship-app-add-ship-dialog',
  templateUrl: './add-ship-dialog.component.html',
  styleUrls: ['./add-ship-dialog.component.scss']
})
export class AddShipDialogComponent {
  shipForm: FormGroup;

  newShip: Ship = {
    id: 0,
    shipNumber:0,
    shipName: '',
    createdYear: 0,
    shipLength: 0,
    shipWidth: 0,
    weightGross: 0,
    weightNet: 0,
    manager: undefined
  };

  constructor(
    public dialogRef: MatDialogRef<AddShipDialogComponent>,
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.shipForm = this.fb.group({
      id: ['', Validators.required],
      shipNumber: ['', Validators.required],
      shipName: ['', Validators.required],
      createdYear: [''],
      shipLength: ['', Validators.required],
      shipWidth: ['', Validators.required],
      weightGross: [''],
      weightNet: [''],
      createdById: ['']
    });
  }

  onSave() {
    this.dialogRef.close(this.newShip);
  }

  onCancel() {
    this.dialogRef.close();
  }

}
