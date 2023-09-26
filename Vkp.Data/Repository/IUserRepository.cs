using System;
using System.Threading.Tasks;
using Vkp.Base.Model;
using Vkp.Data.Domain;

namespace Vkp.Data.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByTCKNAsync(string tckn);
    }
}
