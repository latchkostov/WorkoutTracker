import { NgModule } from '@angular/core';
import { SharedModule } from './shared.module';

import { MuscleGroupService } from '../services/muscle-group.service';

@NgModule({
  imports: [
    SharedModule
  ],
  declarations: [],
  providers: [
    MuscleGroupService
  ]
})
export class MuscleGroupModule { }
