using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vkp.Data.Domain;
using Vkp.Data.Repository;

namespace Vkp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IGenericRepository<Vote> _voteRepository;
        private readonly IGenericRepository<Candidate> _candidateRepository;

        public VoteController(
            IGenericRepository<Vote> voteRepository,
            IGenericRepository<Candidate> candidateRepository)
        {
            _voteRepository = voteRepository;
            _candidateRepository = candidateRepository;
        }

        // Voting
        [HttpPost("Vote")]
        public async Task<IActionResult> Vote(int userId, int candidateId)
        {
            try
            {
                // Checking user has votes
                var existingVote = await _voteRepository.FindAsync(v => v.UserId == userId);
                if (existingVote != null)
                {
                    return BadRequest("The user has already voted.");
                }

                // Find candidadtes and vote
                var candidate = await _candidateRepository.GetByIdAsync(candidateId);
                if (candidate == null)
                {
                    return NotFound("No candidate found.");
                }

                var vote = new Vote
                {
                    UserId = userId,
                    CandidateId = candidateId,
                    VoteDate = DateTime.Now
                };

                await _voteRepository.AddAsync(vote);

                return Ok("The vote was successfully recorded.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get all votes
        [HttpGet("AllVotes")]
        public async Task<ActionResult<IEnumerable<Vote>>> GetAllVotes()
        {
            try
            {
                var votes = await _voteRepository.GetAllAsync();
                return Ok(votes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Calculating vote results
        [HttpGet("Results")]
        public async Task<IActionResult> GetResults()
        {
            try
            {
                var candidateVotes = new Dictionary<Candidate, int>();

                // Take all the candidates and calculate the number of votes for each
                var candidates = await _candidateRepository.GetAllAsync();
                foreach (var candidate in candidates)
                {
                    var voteCount = await _voteRepository.CountAsync(v => v.CandidateId == candidate.Id);
                    candidateVotes[candidate] = voteCount;
                }

                // Sort results
                var sortedResults = candidateVotes.OrderByDescending(kv => kv.Value);

                return Ok(sortedResults);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
