using Microsoft.AspNetCore.Mvc;
using Vkp.Data.Domain;
using Vkp.Data.Repository;
using Vkp.Data.Dtos;
using Vkp.Data.Extensions;

namespace Vkp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IGenericRepository<Candidate> _candidateRepository;

        public CandidateController(IGenericRepository<Candidate> candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        // An endpoint that returns all candidates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidateDto>>> GetCandidates()
        {
            var candidates = await _candidateRepository.GetAllAsync();
            var candidateDtos = candidates.Select(candidate => candidate.ToDto());
            return Ok(candidateDtos);
        }

        // An endpoint that returns a specific candidate by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDto>> GetCandidate(int id)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            CandidateDto candidateDto = candidate.ToDto();

            return Ok(candidateDto);
        }

        // An endpoint that creates a new candidate
        [HttpPost]
        public async Task<ActionResult<CandidateDto>> CreateCandidate(CandidateDto candidateDto)
        {
            var existingCandidate = await _candidateRepository.FindAsync(x => x.Name == candidateDto.Name && candidateDto.Party == candidateDto.Party);
            // Convert from DTO to database object

            if (existingCandidate != null)
            {
                return Conflict("There is already another candidate with the same name and party.");
            }

            var candidate = new Candidate
            {
                Name = candidateDto.Name,
                Party = candidateDto.Party
            };

            await _candidateRepository.AddAsync(candidate);

            // Convert the added database object back to DTO
            var createdCandidateDto = candidate.ToDto();

            return CreatedAtAction(nameof(GetCandidate), new { id = createdCandidateDto.Id }, createdCandidateDto);
        }

        // An endpoint that updates a specific candidate
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, CandidateDto candidateDto)
        {
            if (id != candidateDto.Id)
            {
                return BadRequest();
            }

            // If no candidate is found, NotFound is returned.
            var existingCandidate = await _candidateRepository.GetByIdAsync(id);
            if (existingCandidate == null)
            {
                return NotFound();
            }

            // Convert from DTO to database object
            existingCandidate.Name = candidateDto.Name;
            existingCandidate.Party = candidateDto.Party;

            await _candidateRepository.UpdateAsync(existingCandidate);

            return NoContent();
        }

        // An endpoint that deletes a specific candidate
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            // If no candidate is found, NotFound is returned.
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            await _candidateRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
