using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Services;

namespace WorkoutTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/Exercises")]
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        
        /// <summary>
        /// Retrieves a list of all of the exercises.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            return Json(await _exerciseService.GetAll());
        }
    }
}