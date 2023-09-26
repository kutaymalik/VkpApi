namespace Vkp.Data.Dtos;

public class VoteDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CandidateId { get; set; }
    public DateTime VoteDate { get; set; }
}