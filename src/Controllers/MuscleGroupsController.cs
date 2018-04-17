using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Models.DTOs;
using WorkoutTracker.Services;

namespace WorkoutTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/MuscleGroups")]
    public class MuscleGroupsController : Controller
    {
        private readonly IMuscleGroupService _muscleGroupService;
        private readonly IMapper _mapper;

        public MuscleGroupsController(IMuscleGroupService muscleGroupService, IMapper mapper)
        {
            _muscleGroupService = muscleGroupService;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Retrieves a list of all of the muscle groups.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _muscleGroupService.GetAll();

            var result = _mapper.Map<IEnumerable<MuscleGroupDto>>(entities);
            return Json(result);
        }
    }
}