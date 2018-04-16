using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WorkoutTracker.Models
{
    /// <summary>
    /// Muscle group model.
    /// </summary>
    public class MuscleGroup : BaseModel
    {
        /// <summary>
        /// The name of the muscle group.
        /// </summary>
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<ExerciseMuscleGroupJoin> ExerciseMuscleGroups { get; set; } =
            new List<ExerciseMuscleGroupJoin>();

        /// <summary>
        /// The exercises that develop this muscle group.
        /// </summary>
        public ICollection<Exercise> Exercises => ExerciseMuscleGroups.Select(x => x.Exercise).ToList();
    }
}
