import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteShipDialogComponent } from './delete-ship-dialog.component';

describe('DeleteShipDialogComponent', () => {
  let component: DeleteShipDialogComponent;
  let fixture: ComponentFixture<DeleteShipDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeleteShipDialogComponent]
    });
    fixture = TestBed.createComponent(DeleteShipDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
