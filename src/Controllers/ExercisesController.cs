using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkoutTracker.Exceptions;
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

        private const string GET_EXERCISE_BY_ID_ROUTE = "GetExerciseById";

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

        /// <summary>
        /// Retrieves an exercise using its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = GET_EXERCISE_BY_ID_ROUTE)]
        public async Task<IActionResult> GetExerciseById(int id)
        {
            var entity = await _exerciseService.Get(id);

            if (entity == null)
                return NotFound();

            var result = _mapper.Map<ExerciseDto>(entity);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves an exercise using its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetExerciseByName(string name)
        {
            var entity = await _exerciseService.Get(name);

            if (entity == null)
                return NotFound();

            var result = _mapper.Map<ExerciseDto>(entity);
            return Ok(result);
        }

        /// <summary>
        /// Add an exercise.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddExercise([FromBody]ExerciseAddDto dto)
        {
            if (dto == null || !ModelState.IsValid) return BadRequest();

            try
            {
                var entity = await _exerciseService.Add(dto.Name, dto.Description);
                var result = _mapper.Map<ExerciseDto>(entity);
                return CreatedAtRoute(GET_EXERCISE_BY_ID_ROUTE, new { id = result.Id }, result);
            }
            catch (EntityExistsException)
            {
                return new StatusCodeResult((int)HttpStatusCode.Conflict);
            }
        }
    }
}