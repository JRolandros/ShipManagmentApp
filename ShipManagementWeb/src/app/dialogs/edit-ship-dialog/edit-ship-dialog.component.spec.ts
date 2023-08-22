import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditShipDialogComponent } from './edit-ship-dialog.component';

describe('EditShipDialogComponent', () => {
  let component: EditShipDialogComponent;
  let fixture: ComponentFixture<EditShipDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditShipDialogComponent]
    });
    fixture = TestBed.createComponent(EditShipDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
