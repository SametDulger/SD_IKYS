using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;

namespace SD_IKYS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerformanceEvaluationsController : ControllerBase
    {
        private readonly IPerformanceEvaluationService _performanceEvaluationService;

        public PerformanceEvaluationsController(IPerformanceEvaluationService performanceEvaluationService)
        {
            _performanceEvaluationService = performanceEvaluationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerformanceEvaluationDto>>> GetAll()
        {
            var evaluations = await _performanceEvaluationService.GetAllAsync();
            return Ok(evaluations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PerformanceEvaluationDto>> GetById(int id)
        {
            var evaluation = await _performanceEvaluationService.GetByIdAsync(id);
            if (evaluation == null)
                return NotFound();

            return Ok(evaluation);
        }

        [HttpPost]
        public async Task<ActionResult<PerformanceEvaluationDto>> Create(CreatePerformanceEvaluationDto createDto)
        {
            try
            {
                var evaluation = await _performanceEvaluationService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = evaluation.Id }, evaluation);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PerformanceEvaluationDto>> Update(int id, UpdatePerformanceEvaluationDto updateDto)
        {
            try
            {
                var evaluation = await _performanceEvaluationService.UpdateAsync(id, updateDto);
                return Ok(evaluation);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _performanceEvaluationService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<PerformanceEvaluationDto>>> GetByEmployee(int employeeId)
        {
            var evaluations = await _performanceEvaluationService.GetByEmployeeAsync(employeeId);
            return Ok(evaluations);
        }

        [HttpGet("evaluator/{evaluatorId}")]
        public async Task<ActionResult<IEnumerable<PerformanceEvaluationDto>>> GetByEvaluator(int evaluatorId)
        {
            var evaluations = await _performanceEvaluationService.GetByEvaluatorAsync(evaluatorId);
            return Ok(evaluations);
        }

        [HttpGet("period/{period}")]
        public async Task<ActionResult<IEnumerable<PerformanceEvaluationDto>>> GetByPeriod(string period)
        {
            var evaluations = await _performanceEvaluationService.GetByPeriodAsync(period);
            return Ok(evaluations);
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<PerformanceEvaluationDto>>> GetByStatus(string status)
        {
            var evaluations = await _performanceEvaluationService.GetByStatusAsync(status);
            return Ok(evaluations);
        }

        [HttpGet("high-performers")]
        public async Task<ActionResult<IEnumerable<PerformanceEvaluationDto>>> GetHighPerformers()
        {
            var evaluations = await _performanceEvaluationService.GetHighPerformersAsync();
            return Ok(evaluations);
        }

        [HttpGet("report")]
        public async Task<ActionResult<object>> GetReport()
        {
            var report = await _performanceEvaluationService.GetReportAsync();
            return Ok(report);
        }

        [HttpGet("average-score")]
        public async Task<ActionResult<decimal>> GetAverageScore()
        {
            var averageScore = await _performanceEvaluationService.GetAverageScoreAsync();
            return Ok(averageScore);
        }
    }
} 