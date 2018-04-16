using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Services;

namespace WorkoutTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/MuscleGroups")]
    public class MuscleGroupsController : Controller
    {
        private readonly IMuscleGroupService _muscleGroupService;

        public MuscleGroupsController(IMuscleGroupService muscleGroupService)
        {
            _muscleGroupService = muscleGroupService;
        }
        
        /// <summary>
        /// Retrieves a list of all of the muscle groups.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _muscleGroupService.GetAll();
            return Json(result);
        }
    }
}