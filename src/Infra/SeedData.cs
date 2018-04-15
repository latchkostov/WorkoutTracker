using System.Collections.Generic;
using System.Linq;
using WorkoutTracker.Models;

namespace WorkoutTracker.Infra
{
    public static class SeedData
    {
        public static List<Exercise> Exercises = new List<Exercise>
        {
            new Exercise
            {
                Name = "Bench Press",
                Description = "Lift a barbell with some weights while laying down",
                VideoLink = "http://example.com"
            },
            new Exercise
            {
                Name = "Bicep Curl",
                Description = "",
                VideoLink = "http://example.com"
            }
        };

        private static List<MuscleGroup> MuscleGroups = new List<MuscleGroup>()
        {
            new MuscleGroup
            {
                Name = "Chest"
            },
            new MuscleGroup
            {
                Name = "Triceps"
            },
            new MuscleGroup
            {
                Name = "Biceps"
            }
        };

        /// <summary>
        /// Exercises and related muscle groups.
        /// </summary>
        public static List<ExerciseMuscleGroupJoin> ExerciseMuscleGroups = new List<ExerciseMuscleGroupJoin>()
        {
            new ExerciseMuscleGroupJoin {
                Exercise = Exercises.First(x => x.Name == "Bench Press"),
                MuscleGroup = MuscleGroups.First(x => x.Name == "Chest")
            },
            new ExerciseMuscleGroupJoin {
                Exercise = Exercises.First(x => x.Name == "Bench Press"),
                MuscleGroup = MuscleGroups.First(x => x.Name == "Triceps")
            },
            new ExerciseMuscleGroupJoin {
                Exercise = Exercises.First(x => x.Name == "Bicep Curl"),
                MuscleGroup = MuscleGroups.First(x => x.Name == "Biceps")
            }
        };
    }
}
