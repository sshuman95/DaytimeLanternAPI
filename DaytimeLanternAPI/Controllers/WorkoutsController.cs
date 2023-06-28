using DaytimeLanternAPI.Exceptions;
using DaytimeLanternAPI.Models.Workout;
using DaytimeLanternAPI.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DaytimeLanternAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutsController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
            var result = await _workoutService.GetWorkouts();
            return Ok(result);
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(Guid id)
        {
            var workout = await _workoutService.GetWorkout(id);

            if (workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        // PUT: api/Workouts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkout([FromRoute] Guid id, UpdateWorkoutRequest req)
        {
            if (id != req.WorkoutId)
            {
                return BadRequest();
            }

            if (String.IsNullOrEmpty(req.Name))
            {
                return BadRequest("A name is required!");
            }

            try
            {
                await _workoutService.PutWorkout(id, req);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_workoutService.WorkoutExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Workouts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        ///
        [HttpPost]
        public async Task<ActionResult<Workout>> PostWorkout(CreateWorkoutRequest request)
        {

            if (request == null)
            {
                return BadRequest();
            }

            if (String.IsNullOrEmpty(request.Name))
            {
                return BadRequest("A name is required!");
            }

            var response = await _workoutService.PostWorkout(request);

            if (response == null)
            {
                return BadRequest("Failed to create workout");
            }

            return CreatedAtAction(nameof(GetWorkout), new { id = response.Id }, response);
        }

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(Guid id)
        {
            try
            {
                await _workoutService.DeleteWorkout(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
