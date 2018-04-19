import { Inject, Component } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-exercise-add-dialog',
  templateUrl: 'exercise-add-dialog.component.html',
})
export class ExerciseAddDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<ExerciseAddDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
    }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
