using DaytimeLanternAPI.Data;
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

        public WorkoutsController(WorkoutDbContext context, IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        // GET: api/Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
        {
            if (_workoutService.IsInvalidContext())
            {
                return NotFound();
            }
            var result = await _workoutService.GetWorkouts();
            return Ok(result);
        }

        // GET: api/Workouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(Guid id)
        {
            if (_workoutService.IsInvalidContext())
            {
                return NotFound();
            }
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
        public async Task<IActionResult> PutWorkout(Guid id, Workout workout)
        {
            if (id != workout.Id)
            {
                return BadRequest();
            }

            try
            {
                await _workoutService.PutWorkout(id, workout);
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
            var response = await _workoutService.PostWorkout(request);

            if (response == null)
            {
                return Problem("Failed to create workout");
            }

            return CreatedAtAction("GetWorkout", new { id = response.Id }, response);
        }

        // DELETE: api/Workouts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(Guid id)
        {
            if (_workoutService.IsInvalidContext())
            {
                return NotFound();
            }
            await _workoutService.DeleteWorkout(id);

            return NoContent();
        }
    }
}
