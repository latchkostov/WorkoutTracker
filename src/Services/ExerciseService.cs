using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Infra;
using WorkoutTracker.Models;
using WorkoutTracker.Models.Entities;

namespace WorkoutTracker.Services
{
    /// <summary>
    /// Service for management of exercises.
    /// </summary>
    public class ExerciseService : IExerciseService
    {
        private readonly WorkoutTrackerContext _context;

        public ExerciseService(WorkoutTrackerContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// Retrives all exercises.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _context.Exercises
                .Include(exercise => exercise.ExerciseMuscleGroups)
                    .ThenInclude(x => x.MuscleGroup)
                .ToListAsync();
        }
    }
}
