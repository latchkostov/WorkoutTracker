using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTracker.Models.DTOs
{
    public class MuscleGroupDto : BaseDto
    {
        /// <summary>
        /// The name of the muscle group.
        /// </summary>
        public string Name { get; set; }
    }
}
