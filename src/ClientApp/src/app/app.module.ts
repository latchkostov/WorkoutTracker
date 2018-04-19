import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AppNavbarComponent } from './components/app-navbar/app-navbar.component';
import { HomeComponent } from './components/home/home.component';

import { SharedModule } from './modules/shared.module';
import { ExerciseModule } from './modules/exercise.module';
import { MuscleGroupModule } from './modules/muscle-group.module';


@NgModule({
  declarations: [
    AppComponent,
    AppNavbarComponent,
    HomeComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: '**', component: HomeComponent }
    ]),
    ExerciseModule,
    SharedModule,
    MuscleGroupModule,
  ],
  exports: [
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
