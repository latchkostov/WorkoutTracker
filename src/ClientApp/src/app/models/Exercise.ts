import { MuscleGroup } from './MuscleGroup';

export interface IExercise {
    id: number;
    name: string;
    description: string;
    videoLink: string;
    muscleGroups: MuscleGroup[];

    isCompound(): boolean;
}

export class Exercise implements IExercise {
    constructor(id: number, name: string, description: string, videoLink: string, muscleGroups: MuscleGroup[]) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.videoLink = videoLink;
        this.muscleGroups = muscleGroups;
    }

    id: number;
    name: string;
    description: string;
    videoLink: string;
    muscleGroups: MuscleGroup[];

    isCompound() {
        if (this.muscleGroups && this.muscleGroups.length > 1) { return true; }
        return false;
    }
}
