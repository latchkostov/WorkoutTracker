import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExerciseAddDialogComponent } from './exercise-add-dialog.component';

describe('ExerciseAddDialogComponent', () => {
  let component: ExerciseAddDialogComponent;
  let fixture: ComponentFixture<ExerciseAddDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExerciseAddDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExerciseAddDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
