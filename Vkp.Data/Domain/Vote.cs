using System.ComponentModel.DataAnnotations.Schema;
using Vkp.Base.Model;

namespace Vkp.Data.Domain;

public class Vote : BaseModel
{
    [ForeignKey("User")]
    public int UserId { get; set; }
    public int CandidateId { get; set; }
    public DateTime VoteDate { get; set; }
    public virtual User User { get; set; }
    public virtual Candidate Candidate { get; set; }
}
