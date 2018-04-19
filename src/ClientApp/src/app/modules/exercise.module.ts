import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { ExerciseListComponent } from '../components/exercise-list/exercise-list.component';
import { ExerciseDetailsComponent } from '../components/exercise-details/exercise-details.component';
import { ExerciseAddDialogComponent } from '../components/exercise-add-dialog/exercise-add-dialog.component';
import { ExerciseService } from '../services/exercise.service';
import { SharedModule } from './shared.module';

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild([
      { path: 'exercises', component: ExerciseListComponent },
      { path: 'exercise/:id', component: ExerciseDetailsComponent, pathMatch: 'full' }
    ]),
  ],
  declarations: [
    ExerciseListComponent,
    ExerciseDetailsComponent,
    ExerciseAddDialogComponent
  ],
  entryComponents: [
    ExerciseAddDialogComponent
  ],
  providers: [
    ExerciseService
  ]
})
export class ExerciseModule { }
