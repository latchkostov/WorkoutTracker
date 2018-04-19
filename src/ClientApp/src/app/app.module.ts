import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatFormFieldModule, MatDialogModule, MatInputModule } from '@angular/material';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MultiSelectModule } from 'primeng/multiselect';
import { RadioButtonModule } from 'primeng/radiobutton';
import { GrowlModule } from 'primeng/growl';

import { AppComponent } from './app.component';
import { ExerciseListComponent } from './components/exercise-list/exercise-list.component';
import { ExerciseService } from './services/exercise.service';
import { MuscleGroupService } from './services/muscle-group.service';
import { AppNavbarComponent } from './components/app-navbar/app-navbar.component';
import { ExerciseDetailsComponent } from './components/exercise-details/exercise-details.component';
import { ExerciseAddDialogComponent } from './components/exercise-add-dialog/exercise-add-dialog.component';
import { MessageService } from 'primeng/components/common/messageservice';

@NgModule({
  declarations: [
    AppComponent,
    ExerciseListComponent,
    AppNavbarComponent,
    ExerciseDetailsComponent,
    ExerciseAddDialogComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FormsModule,
    GrowlModule,
    HttpClientModule,
    MatButtonModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule,
    MultiSelectModule,
    NgbModule.forRoot(),
    RadioButtonModule,
    RouterModule.forRoot([
      { path: '', component: ExerciseListComponent, pathMatch: 'full' },
      { path: 'exercises', component: ExerciseListComponent },
      { path: 'exercise/:id', component: ExerciseDetailsComponent, pathMatch: 'full' }
    ])
  ],
  entryComponents: [
    ExerciseAddDialogComponent
  ],
  providers: [ExerciseService, MuscleGroupService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
