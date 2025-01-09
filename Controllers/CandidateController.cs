using CandidateManagementSystem.Clients;
using CandidateManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateClient _candidateClient;

        public CandidateController(ICandidateClient candidateClient)
        {
            _candidateClient = candidateClient;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<CandidateModel>>> GetCandidates()
        {
            return Ok(await _candidateClient.GetCandidatesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateModel>> GetCandidateById(Guid id)
        {
            var candidate = await _candidateClient.GetCandidateByIdAsync(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        [HttpPost]
        public async Task<ActionResult<CandidateModel>> CreateCandidate(CandidateModel candidate)
        {
            await _candidateClient.AddCandidateAsync(candidate);

            return CreatedAtAction(nameof(GetCandidateById), new { id = candidate.Id }, candidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidate(Guid id, CandidateModel candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            await _candidateClient.UpdateCandidateAsync(candidate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(Guid id)
        {
            var candidate = await _candidateClient.GetCandidateByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            await _candidateClient.DeleteCandidateByIdAsync(id);

            return NoContent();
        }
    }
}