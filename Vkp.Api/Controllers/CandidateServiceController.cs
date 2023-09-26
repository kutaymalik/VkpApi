using Microsoft.AspNetCore.Mvc;
using Vkp.Data.Domain;
using Vkp.Data.Services;

namespace Vkp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidateServiceController : ControllerBase
{
    private readonly ICandidateService _candidateService;

    public CandidateServiceController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    // An endpoint that fetches all candidates
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidates()
    {
        try
        {
            var candidates = await _candidateService.GetCandidatesAsync();
            return Ok(candidates);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // An endpoint that returns a specific candidate by ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Candidate>> GetCandidate(int id)
    {
        try
        {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
}
}