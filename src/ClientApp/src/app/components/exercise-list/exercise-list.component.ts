import { Component, OnInit } from '@angular/core';
import { IExercise } from '../../models/Exercise';
import { SelectItem } from 'primeng/api';
import { MuscleGroup } from '../../models/MuscleGroup';
import { ExerciseService } from '../../services/exercise.service';
import { MuscleGroupService } from '../../services/muscle-group.service';

@Component({
  selector: 'app-exercise-list',
  templateUrl: './exercise-list.component.html',
  styleUrls: ['./exercise-list.component.css']
})
export class ExerciseListComponent implements OnInit {

  exercises: IExercise[];
  filteredExercises: IExercise[];

  // Text filter bound property
  _searchValue = '';
  get searchValue(): string {
    return this._searchValue;
  }
  set searchValue(value: string) {
    this._searchValue = value;
    this.performFiltering();
  }

  // Multi-select dropdown bound property
  muscleGroups: SelectItem[];
  _selectedMuscleGroups: SelectItem[];
  get selectedMuscleGroups(): SelectItem[] {
    return this._selectedMuscleGroups;
  }
  set selectedMuscleGroups(value: SelectItem[]) {
    this._selectedMuscleGroups = value;
    this.performFiltering();
  }

  // Radio button bound property
  _exerciseType = 'All';
  get exerciseType(): string {
    return this._exerciseType;
  }
  set exerciseType(value: string) {
    this._exerciseType = value;
    this.performFiltering();
  }

  constructor(
    private exerciseService: ExerciseService,
    private muscleGroupService: MuscleGroupService
  ) {
    this.exerciseService.getAllExercises().subscribe(data => {
      this.exercises = data;
      this.filteredExercises = this.exercises;
    });

    this.muscleGroupService.getAllMuscleGroups().subscribe(data => {
      this.muscleGroups = [];
      for (const muscleGroup of data) {
        this.muscleGroups.push(
          {
            label: muscleGroup.name,
            value: { id: muscleGroup.id, name: muscleGroup.name }
          });
      }
    });
  }

  performFiltering() {
    // First, filter based on the searched text
    const trimmedSearchValue = this.searchValue.trim().toLowerCase();
    if (trimmedSearchValue.length > 0) {
      this.filteredExercises = this.exercises.
        filter(x => (x.name.toLowerCase().indexOf(trimmedSearchValue) > -1) ||
          (x.description.toLowerCase().indexOf(trimmedSearchValue) > -1)
        );
    } else {
      this.filteredExercises = this.exercises;
    }

    // Then, filter based on selected muscle groups
    if (this.selectedMuscleGroups !== undefined && this.selectedMuscleGroups.length > 0) {

      const selectedMuscleGroupIds: number[] = this.selectedMuscleGroups.map(x => x['id']);

      if (selectedMuscleGroupIds.length > 0) {
        this.filteredExercises = this.filteredExercises.filter((exercise: IExercise) => {
          let match = false;
          for (const selectedId of selectedMuscleGroupIds) {
            if (exercise.muscleGroups.map(x => x.id).includes(selectedId)) {
              match = true;
              break;
            }
          }
          return match === true;
        });
      }
    }

    // Filter based on exercise type if selected
    if (this.exerciseType && this.exerciseType.toLowerCase() !== 'all') {
      switch (this.exerciseType) {
        case 'Compound':
          this.filteredExercises = this.filteredExercises.filter((exercise: IExercise) => {
            return this.isCompound(exercise);
          });
          break;
        case 'Isolated':
          this.filteredExercises = this.filteredExercises.filter((exercise: IExercise) => {
            return !this.isCompound(exercise);
          });
          break;
        default:
          break;
      }
    }
  }

  isCompound(exercise: IExercise) {
    if (exercise.muscleGroups && exercise.muscleGroups.length > 1) { return true; }
    return false;
  }

  ngOnInit() {
  }

}
