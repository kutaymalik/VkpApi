using System.ComponentModel.DataAnnotations.Schema;
using Vkp.Base.Model;

namespace Vkp.Data.Domain;

public class User : BaseModel
{
    public string TCKN { get; set; }
    public string Password { get; set; }


    public virtual Vote? Vote { get; set; }
}
