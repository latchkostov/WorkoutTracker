import { TestBed, inject } from '@angular/core/testing';

import { MuscleGroupService } from './muscle-group.service';

describe('MuscleGroupService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MuscleGroupService]
    });
  });

  it('should be created', inject([MuscleGroupService], (service: MuscleGroupService) => {
    expect(service).toBeTruthy();
  }));
});
