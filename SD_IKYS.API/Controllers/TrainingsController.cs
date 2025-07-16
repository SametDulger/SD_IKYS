using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;

namespace SD_IKYS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingsController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingsController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingDto>>> GetAll()
        {
            var trainings = await _trainingService.GetAllAsync();
            return Ok(trainings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingDto>> GetById(int id)
        {
            var training = await _trainingService.GetByIdAsync(id);
            if (training == null)
                return NotFound();

            return Ok(training);
        }

        [HttpPost]
        public async Task<ActionResult<TrainingDto>> Create(CreateTrainingDto createTrainingDto)
        {
            try
            {
                var training = await _trainingService.CreateAsync(createTrainingDto);
                return CreatedAtAction(nameof(GetById), new { id = training.Id }, training);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TrainingDto>> Update(int id, UpdateTrainingDto updateTrainingDto)
        {
            try
            {
                var training = await _trainingService.UpdateAsync(id, updateTrainingDto);
                return Ok(training);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _trainingService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("type/{trainingType}")]
        public async Task<ActionResult<IEnumerable<TrainingDto>>> GetByType(string trainingType)
        {
            var trainings = await _trainingService.GetByTypeAsync(trainingType);
            return Ok(trainings);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<TrainingDto>>> GetByStatus(string status)
        {
            var trainings = await _trainingService.GetByStatusAsync(status);
            return Ok(trainings);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<TrainingDto>>> GetActive()
        {
            var trainings = await _trainingService.GetActiveTrainingsAsync();
            return Ok(trainings);
        }

        [HttpGet("trainer/{trainer}")]
        public async Task<ActionResult<IEnumerable<TrainingDto>>> GetByTrainer(string trainer)
        {
            var trainings = await _trainingService.GetByTrainerAsync(trainer);
            return Ok(trainings);
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<IEnumerable<TrainingDto>>> GetUpcoming()
        {
            var trainings = await _trainingService.GetUpcomingTrainingsAsync();
            return Ok(trainings);
        }

        [HttpGet("completed")]
        public async Task<ActionResult<IEnumerable<TrainingDto>>> GetCompleted()
        {
            var trainings = await _trainingService.GetCompletedTrainingsAsync();
            return Ok(trainings);
        }

        [HttpGet("cancelled")]
        public async Task<ActionResult<IEnumerable<TrainingDto>>> GetCancelled()
        {
            var trainings = await _trainingService.GetCancelledTrainingsAsync();
            return Ok(trainings);
        }
    }
} 