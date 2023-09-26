using Vkp.Base.Model;

namespace Vkp.Data.Domain;

public class Candidate : BaseModel
{
    public string Name { get; set; }
    public string Party { get; set; }

    public virtual ICollection<Vote>? Votes { get; set; }
}
