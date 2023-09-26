using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vkp.Base.Model;
using Vkp.Data.Domain;

namespace Vkp.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByTCKNAsync(string tckn)
        {
            return await FindAsync(u => u.TCKN == tckn);
        }
    }
}
