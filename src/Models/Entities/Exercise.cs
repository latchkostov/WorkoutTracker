using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WorkoutTracker.Models.Entities
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

        [JsonIgnore]
        public virtual ICollection<ExerciseMuscleGroupJoin> ExerciseMuscleGroups { get; set; } = 
            new List<ExerciseMuscleGroupJoin>();

        /// <summary>
        /// Join entities between exercrise and muscle groups.
        /// </summary>
        public ICollection<MuscleGroup> MuscleGroups => ExerciseMuscleGroups.Select(x => x.MuscleGroup).ToList();
    }
}
