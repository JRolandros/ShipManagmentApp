import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Ship } from '../models/ship.model';
import { AddShipDialogComponent } from '../dialogs/add-ship-dialog/add-ship-dialog.component';
import { EditShipDialogComponent } from '../dialogs/edit-ship-dialog/edit-ship-dialog.component';
import { DeleteShipDialogComponent } from '../dialogs/delete-ship-dialog/delete-ship-dialog.component';
import { ShipManagementService } from '../services/ship-management.service';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'ship-app-ship-list',
  templateUrl: './ship-list.component.html',
  styleUrls: ['./ship-list.component.scss']
})
export class ShipListComponent implements OnInit{
  ships: Ship[]=[];
  fakeManager={
    id:1,
    name:'Roland',
    email:'Roland@gmail.com',
    password:''};

  displayedColumns: string[] = ['id', 'shipNumber','shipName', 'createdYear', 'shipLength', 'shipWidth', 'weightGross', 'weightNet', 'createdById', 'actions'];

  constructor(private dialog: MatDialog, private _shipService:ShipManagementService,private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
    console.log('log in onInit');
    this.loadShips();
  }

private loadShips(){
  //Load all ships and display them
  this._shipService.GetShips().subscribe(
    {
      next:(data)=>{
        this.ships=data;
        this._snackBar.open("Load successfully",'Ok',{duration:1000})
      },
      error: (error)=>{
        this._snackBar.open("Error when loading ships",'Ok',{duration:1000})
      }
    }
  );
}

public Reload(){
  this.loadShips();
}

  openAddDialog() {
    const dialogRef = this.dialog.open(AddShipDialogComponent, {
      width: '400px',
      data: {}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('addind',result);
        result.manager=this.fakeManager // Has to be replace with the real one pick from dropdownList in the form.
        // Add the new ship to the ships array
        this._shipService.AddShip(result).subscribe(
          {
            next :(data)=>{
              this._snackBar.open(" Ship added",'Ok',{duration:1000})

              this.loadShips();
            },
            error:(err)=>{}
          }
        );

      }
    });
  }

  openEditDialog(ship: Ship) {
    console.log('ship :',ship);

    const dialogRef = this.dialog.open(EditShipDialogComponent, {
      width: '400px',
      data: { ship }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {

        console.log('dsfdfsdfsdff 22222',result);

        result.manager=this.fakeManager // Has to be replace with the real one pick from dropdownList in the form.

        delete result.createdById //This property is not on the api contract so has to be deleted

        // Update the ship in the ships array
        this._shipService.UpdateShip(result).subscribe(
          {
            next :(data)=>{
              this._snackBar.open(" Ship updated",'Ok',{duration:1000})
              this.loadShips();
            },
            error:(err)=>{}
          }
        );


      }
    });
  }

  openDeleteDialog(ship: Ship): void {
    const dialogRef = this.dialog.open(DeleteShipDialogComponent, {
      data: {ship}
    });
    let that=this;
    dialogRef.afterClosed().subscribe(confirmDelete => {
      if (confirmDelete) {
        that.deleteShip(ship);
      }
    });
  }

  deleteShip(ship: Ship) {
    this._shipService.DeleteShip(ship.id).subscribe(
      {
        next :(data)=>{

          this._snackBar.open(" Ship deleted",'Ok',{duration:1000})
          this.loadShips();
        },
        error:(err)=>{}
      }
    );


  }

}
