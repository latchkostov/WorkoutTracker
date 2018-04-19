export class ExerciseAddDto {
    constructor(name: string, description: string) {
        this.name = name;
        this.description = description;
    }

    name: string;
    description: string;
}
