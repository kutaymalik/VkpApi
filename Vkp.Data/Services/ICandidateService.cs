using Vkp.Data.Domain;

namespace Vkp.Data.Services;

public interface ICandidateService
{
    Task<IEnumerable<Candidate>> GetCandidatesAsync();
    Task<Candidate> GetCandidateByIdAsync(int id);
}
