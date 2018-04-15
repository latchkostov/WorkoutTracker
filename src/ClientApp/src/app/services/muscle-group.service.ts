import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MuscleGroup } from '../models/MuscleGroup';

@Injectable()
export class MuscleGroupService {

  constructor(private httpClient: HttpClient) { }

  getAllMuscleGroups() {
    return this.httpClient.get<MuscleGroup[]>('api/musclegroups');
  }

}
