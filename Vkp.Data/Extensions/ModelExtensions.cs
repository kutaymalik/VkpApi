using Vkp.Data.Domain;
using Vkp.Data.Dtos;

namespace Vkp.Data.Extensions;

public static class ModelExtensions
{
    public static CandidateDto ToDto(this Candidate candidate)
    {
        if (candidate == null)
            return null;

        return new CandidateDto
        {
            Id = candidate.Id,
            Name = candidate.Name,
            Party = candidate.Party
        };
    }

    public static UserDto ToDto(this User user)
    {
        if (user == null)
            return null;

        return new UserDto
        {
            Id = user.Id,
            TCKN = user.TCKN,
            Password = user.Password
        };
    }

    public static VoteDto ToDto(this Vote vote)
    {
        if (vote == null)
            return null;

        return new VoteDto
        {
            Id = vote.Id,
            UserId = vote.UserId,
            CandidateId = vote.CandidateId,
            VoteDate = vote.VoteDate
        };
    }
}
