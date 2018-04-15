using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Models;

namespace WorkoutTracker.Services
{
    /// <summary>
    /// Service for management of exercises.
    /// </summary>
    public class ExerciseService : IExerciseService
    {
        /// <summary>
        /// Retrives all exercises.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Exercise>> GetAll()
        {
            var result = new List<Exercise>();

            result.Add(new Exercise
            {
                Id = 1,
                Name = "Bench Press",
                Description = "Lift a barbell with some weights while laying down",
                VideoLink = "http://example.com",
                MuscleGroups = new List<MuscleGroup>() {
                    new MuscleGroup
                    {
                        Id = 1,
                        Name = "Chest"
                    },
                    new MuscleGroup
                    {
                        Id = 2,
                        Name = "Triceps"
                    }
                }
            });

            result.Add(new Exercise
            {
                Id = 2,
                Name = "Bicep Curl",
                Description = "",
                VideoLink = "http://example.com",
                MuscleGroups = new List<MuscleGroup>() {
                    new MuscleGroup
                    {
                        Id = 3,
                        Name = "Biceps"
                    }
                }
            });

            return result;
        }
    }
}
