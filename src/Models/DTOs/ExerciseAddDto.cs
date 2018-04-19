using System.ComponentModel.DataAnnotations;

namespace WorkoutTracker.Models.DTOs
{
    /// <summary>
    /// A DTO used in HTTP Post in order to add an exercise.
    /// </summary>
    public class ExerciseAddDto
    {
        /// <summary>
        /// The name of the exercise.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The description of the exercise.
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}
