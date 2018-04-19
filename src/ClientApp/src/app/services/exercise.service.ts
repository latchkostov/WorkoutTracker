import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IExercise } from '../models/Exercise';
import { ExerciseAddDto } from '../models/ExerciseAddDto';

@Injectable()
export class ExerciseService {

  constructor(private httpClient: HttpClient) { }

  getAllExercises() {
    return this.httpClient.get<IExercise[]>('api/exercises');
  }

  getExercise(id: number) {
    return this.httpClient.get<IExercise>('api/exercises/' + id);
  }

  addExercise(model: ExerciseAddDto) {
    const headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
    return this.httpClient.post<IExercise>('api/exercises', JSON.stringify(model), { headers: headers });
  }
}
