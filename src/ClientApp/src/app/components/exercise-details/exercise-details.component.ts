import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { ExerciseService } from '../../services/exercise.service';
import 'rxjs/add/operator/switchMap';
import { IExercise } from '../../models/Exercise';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-exercise-details',
  templateUrl: './exercise-details.component.html',
  styleUrls: ['./exercise-details.component.css']
})
export class ExerciseDetailsComponent implements OnInit {

  exerciseObs: Observable<IExercise>;
  selectedId: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private exerciseService: ExerciseService
  ) { }

  ngOnInit() {
    this.exerciseObs =  this.route.paramMap.switchMap((params: ParamMap) => {
      this.selectedId = +params.get('id');
      return this.exerciseService.getExercise(this.selectedId);
    });
  }

  goBackToAllExercises() {
    this.router.navigate(['/exercises']);
  }
}
