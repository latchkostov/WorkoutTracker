using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkoutTracker.Models.Entities
{
    /// <summary>
    /// Entity for many-to-many relation of Exercises and Muscle Groups.
    /// </summary>
    public class ExerciseMuscleGroupJoin
    {
        /// <summary>
        /// Id of the exercise.
        /// </summary>
        public int ExerciseId { get; set; }

        /// <summary>
        /// Exercise.
        /// </summary>
        public virtual Exercise Exercise { get; set; }

        /// <summary>
        /// Id of the muscle group.
        /// </summary>
        public int MuscleGroupId { get; set; }

        /// <summary>
        /// Muscle group.
        /// </summary>
        public virtual MuscleGroup MuscleGroup { get; set; }
    }
}
