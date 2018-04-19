import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { IExercise } from '../../models/Exercise';
import { SelectItem } from 'primeng/api';
import { MuscleGroup } from '../../models/MuscleGroup';
import { ExerciseService } from '../../services/exercise.service';
import { MuscleGroupService } from '../../services/muscle-group.service';
import { ExerciseAddDialogComponent } from '../exercise-add-dialog/exercise-add-dialog.component';
import { ExerciseAddDto } from '../../models/ExerciseAddDto';
import { Subscription } from 'rxjs/Subscription';
import { Message } from 'primeng/api';
import { MessageService } from 'primeng/components/common/messageservice';

@Component({
  selector: 'app-exercise-list',
  templateUrl: './exercise-list.component.html',
  styleUrls: ['./exercise-list.component.css']
})
export class ExerciseListComponent implements OnInit, OnDestroy {

  exercises: IExercise[];
  filteredExercises: IExercise[];
  addExerciseName: string;
  addExerciseDescription: string;

  retrieveExercisesSub: Subscription;
  retrieveMuscleGroupsSub: Subscription;
  addExerciseSub: Subscription;

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
    private muscleGroupService: MuscleGroupService,
    public dialog: MatDialog,
    private messageService: MessageService
  ) {
  }

  ngOnInit() {
    this.retrieveExercises();
    this.retrieveMuscleGroups();
  }

  retrieveExercises() {
    this.retrieveExercisesSub = this.exerciseService.getAllExercises().subscribe(data => {
      this.exercises = data;
      this.filteredExercises = this.exercises;
    });
  }

  retrieveMuscleGroups() {
    this.retrieveMuscleGroupsSub = this.muscleGroupService.getAllMuscleGroups().subscribe(data => {
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

  openAddExerciseDialog(): void {
    const dialogRef = this.dialog.open(ExerciseAddDialogComponent, {
      width: '250px',
      data: { exerciseName: this.addExerciseName, exerciseDescription: this.addExerciseDescription }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result && result.exerciseName && result.exerciseDescription) {
        const exerciseName: string = result.exerciseName.trim();
        const exerciseDescription: string = result.exerciseDescription.trim();

        if (exerciseName.length > 0 && exerciseDescription.length > 0) {
          const model = new ExerciseAddDto(exerciseName, exerciseDescription);
          this.exerciseService.addExercise(model).subscribe(
            data => {
              this.retrieveExercises();
            },
            error => {
              // Error
              if (error.status === 409) {
                console.log('Excercise with name already exists');
                this.messageService.add({
                  severity: 'error',
                  summary: 'Exercise exists',
                  detail: 'Exercise with name ' + exerciseName + 'already exists'
                });
              }
            }
          );
        }
      }
    });
  }

  unsubscribe(): void {
    if (this.retrieveExercisesSub) {
      this.retrieveExercisesSub.unsubscribe();
    }
    if (this.retrieveMuscleGroupsSub) {
      this.retrieveMuscleGroupsSub.unsubscribe();
    }
    if (this.addExerciseSub) {
      this.addExerciseSub.unsubscribe();
    }
  }

  ngOnDestroy() {
    this.unsubscribe();
  }
}
