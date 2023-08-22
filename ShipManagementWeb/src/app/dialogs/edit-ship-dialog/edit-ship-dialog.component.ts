import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Ship } from 'src/app/models/ship.model';

@Component({
  selector: 'ship-app-edit-ship-dialog',
  templateUrl: './edit-ship-dialog.component.html',
  styleUrls: ['./edit-ship-dialog.component.scss']
})
export class EditShipDialogComponent {

  shipForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<EditShipDialogComponent>,
    private fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    console.log('ship sent :',data);

    this.shipForm = this.fb.group({
      id:[data.ship.id],
      shipNumber: [data.ship.shipNumber],
      shipName: [data.ship.shipName],
      createdYear:[data.ship.createdYear],
      shipLength: [data.ship.shipLength],
      shipWidth: [data.ship.shipWidth],
      weightGross: [data.ship.weightGross],
      weightNet: [data.ship.weightNet],
      createdById: [this.getManagerName(data.ship)]
    });
  }

  private getManagerName(ship:Ship){
    console.log('dfdfdfdfdfdfdf ',ship);

    return ship.manager?.name;
  }
  onCancel() {
    this.dialogRef.close();
  }

}
