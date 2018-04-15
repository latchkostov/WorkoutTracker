using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Infra;
using WorkoutTracker.Models;

namespace WorkoutTracker.Services
{
    /// <summary>
    /// Service for management of muscle groups.
    /// </summary>
    public class MuscleGroupService : IMuscleGroupService
    {
        private readonly WorkoutTrackerContext _context;

        public MuscleGroupService(WorkoutTrackerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrives all muscle groups.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MuscleGroup>> GetAll()
        {
            return await _context.MuscleGroups
                .Include(p => p.ExerciseMuscleGroups)
                .ToListAsync();
        }
    }
}
