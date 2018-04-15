using System.Collections.Generic;

namespace WorkoutTracker.Models
{

    /// <summary>
    /// Exercise model.
    /// </summary>
    public class Exercise : BaseModel
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
        /// A link to the exercise.
        /// </summary>
        public string VideoLink { get; set; }

        /// <summary>
        /// The muscle groups the exercise involves.
        /// </summary>
        public List<MuscleGroup> MuscleGroups { get; set; } = new List<MuscleGroup>();
    }
}
