using System.Collections.Generic;

namespace WorkoutTracker.Models.DTOs
{
    public class ExerciseDto : BaseDto
    {
        /// <summary>
        /// The name of the exercise.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A description of the exercise.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A link to a demonstration video of this exercise.
        /// </summary>
        public string VideoLink { get; set; }

        /// <summary>
        /// The muscle groups which this exercise develops.
        /// </summary>
        public IEnumerable<MuscleGroupDto> MuscleGroups { get; set; }
    }
}
