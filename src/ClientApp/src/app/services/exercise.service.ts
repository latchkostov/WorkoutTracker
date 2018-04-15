import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IExercise } from '../models/Exercise';

@Injectable()
export class ExerciseService {

  constructor(private httpClient: HttpClient) { }

  getAllExercises() {
    return this.httpClient.get<IExercise[]>('assets/sampleExercises.json');
  }

}
