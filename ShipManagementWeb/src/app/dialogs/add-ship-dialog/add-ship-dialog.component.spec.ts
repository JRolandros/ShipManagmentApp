import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddShipDialogComponent } from './add-ship-dialog.component';

describe('AddShipDialogComponent', () => {
  let component: AddShipDialogComponent;
  let fixture: ComponentFixture<AddShipDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddShipDialogComponent]
    });
    fixture = TestBed.createComponent(AddShipDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
