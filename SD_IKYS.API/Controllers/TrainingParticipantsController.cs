using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;

namespace SD_IKYS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingParticipantsController : ControllerBase
    {
        private readonly ITrainingParticipantService _trainingParticipantService;

        public TrainingParticipantsController(ITrainingParticipantService trainingParticipantService)
        {
            _trainingParticipantService = trainingParticipantService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingParticipantDto>>> GetAll()
        {
            var participants = await _trainingParticipantService.GetAllAsync();
            return Ok(participants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingParticipantDto>> GetById(int id)
        {
            var participant = await _trainingParticipantService.GetByIdAsync(id);
            if (participant == null)
                return NotFound();

            return Ok(participant);
        }

        [HttpPost]
        public async Task<ActionResult<TrainingParticipantDto>> Create(CreateTrainingParticipantDto createDto)
        {
            try
            {
                var participant = await _trainingParticipantService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = participant.Id }, participant);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TrainingParticipantDto>> Update(int id, UpdateTrainingParticipantDto updateDto)
        {
            try
            {
                var participant = await _trainingParticipantService.UpdateAsync(id, updateDto);
                return Ok(participant);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _trainingParticipantService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("training/{trainingId}")]
        public async Task<ActionResult<IEnumerable<TrainingParticipantDto>>> GetByTraining(int trainingId)
        {
            var participants = await _trainingParticipantService.GetByTrainingAsync(trainingId);
            return Ok(participants);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<TrainingParticipantDto>>> GetByEmployee(int employeeId)
        {
            var participants = await _trainingParticipantService.GetByEmployeeAsync(employeeId);
            return Ok(participants);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<TrainingParticipantDto>>> GetByStatus(string status)
        {
            var participants = await _trainingParticipantService.GetByStatusAsync(status);
            return Ok(participants);
        }

        [HttpGet("check-registration/{trainingId}/{employeeId}")]
        public async Task<ActionResult<bool>> CheckRegistration(int trainingId, int employeeId)
        {
            var isRegistered = await _trainingParticipantService.IsEmployeeRegisteredAsync(trainingId, employeeId);
            return Ok(isRegistered);
        }

        [HttpPut("{id}/score")]
        public async Task<ActionResult<TrainingParticipantDto>> UpdateScore(int id, UpdateTrainingScoreDto scoreDto)
        {
            try
            {
                var participant = await _trainingParticipantService.UpdateScoreAsync(id, scoreDto);
                return Ok(participant);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("completed")]
        public async Task<ActionResult<IEnumerable<TrainingParticipantDto>>> GetCompleted()
        {
            var participants = await _trainingParticipantService.GetCompletedParticipantsAsync();
            return Ok(participants);
        }

        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<TrainingParticipantDto>>> GetPending()
        {
            var participants = await _trainingParticipantService.GetPendingParticipantsAsync();
            return Ok(participants);
        }

        [HttpGet("high-scores")]
        public async Task<ActionResult<IEnumerable<TrainingParticipantDto>>> GetHighScores()
        {
            var participants = await _trainingParticipantService.GetHighScoreParticipantsAsync();
            return Ok(participants);
        }
    }
} 