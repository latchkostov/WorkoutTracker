using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Models.DTOs;
using WorkoutTracker.Services;

namespace WorkoutTracker.Controllers
{
    [Produces("application/json")]
    [Route("api/Exercises")]
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;
        private readonly IMapper _mapper;

        public ExercisesController(IExerciseService exerciseService, IMapper mapper)
        {
            _exerciseService = exerciseService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of all of the exercises.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            var entities = await _exerciseService.GetAll();

            var result = _mapper.Map<IEnumerable<ExerciseDto>>(entities);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            var entity = await _exerciseService.Get(id);

            if (entity == null)
                return NotFound();

            var result = _mapper.Map<ExerciseDto>(entity);
            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetExerciseById(string name)
        {
            var entity = await _exerciseService.Get(name);

            if (entity == null)
                return NotFound();

            var result = _mapper.Map<ExerciseDto>(entity);
            return Ok(result);
        }
    }
}