using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutTracker.Models;

namespace WorkoutTracker.Services
{
    /// <summary>
    /// Service for management of muscle groups.
    /// </summary>
    public class MuscleGroupService : IMuscleGroupService
    {
        /// <summary>
        /// Retrives all muscle groups.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<MuscleGroup>> GetAll()
        {
            var result = new List<MuscleGroup>();

            result.AddRange(new List<MuscleGroup>()
            {
                new MuscleGroup
                {
                    Id = 1,
                    Name = "Chest"
                },
                new MuscleGroup
                {
                    Id = 2,
                    Name = "Triceps"
                },
                new MuscleGroup
                {
                    Id = 3,
                    Name = "Biceps"
                }
            });

            return result;
        }
    }
}
