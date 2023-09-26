using Vkp.Data.Services;
using Vkp.Data.Domain;

namespace Vkp.Data.Services;

public class FakeCandidateService : ICandidateService
{
    private readonly List<Candidate> _candidates;

    public FakeCandidateService()
    {
        _candidates = new List<Candidate>
        {
            new Candidate { Id = 1, Name = "Candidate1", Party = "Party A" },
            new Candidate { Id = 2, Name = "Candidate2", Party = "Party B" },
            new Candidate { Id = 3, Name = "Candidate3", Party = "Party C" },
            new Candidate { Id = 4, Name = "Candidate4", Party = "Party D" },
            new Candidate { Id = 5, Name = "Candidate5", Party = "Party E" },
        };
    }
    public async Task<Candidate> GetCandidateByIdAsync(int id)
    {
        return await Task.FromResult(_candidates.FirstOrDefault(x => x.Id == id));
    }

    public async Task<IEnumerable<Candidate>> GetCandidatesAsync()
    {
        return await Task.FromResult(_candidates);
    }
}
