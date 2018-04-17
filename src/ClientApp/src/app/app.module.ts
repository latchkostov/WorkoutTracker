import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MultiSelectModule } from 'primeng/multiselect';
import { RadioButtonModule } from 'primeng/radiobutton';

import { AppComponent } from './app.component';
import { ExerciseListComponent } from './components/exercise-list/exercise-list.component';
import { ExerciseService } from './services/exercise.service';
import { MuscleGroupService } from './services/muscle-group.service';
import { AppNavbarComponent } from './components/app-navbar/app-navbar.component';
import { ExerciseDetailsComponent } from './components/exercise-details/exercise-details.component';

@NgModule({
  declarations: [
    AppComponent,
    ExerciseListComponent,
    AppNavbarComponent,
    ExerciseDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MultiSelectModule,
    NgbModule.forRoot(),
    RadioButtonModule,
    RouterModule.forRoot([
      { path: '', component: ExerciseListComponent, pathMatch: 'full' },
      { path: 'exercises', component: ExerciseListComponent },
      { path: 'exercise/:id', component: ExerciseDetailsComponent, pathMatch: 'full' }
    ])
  ],
  providers: [ExerciseService, MuscleGroupService],
  bootstrap: [AppComponent]
})
export class AppModule { }
