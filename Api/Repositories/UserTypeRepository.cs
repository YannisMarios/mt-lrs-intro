using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class UserTypeRepository : Repository<UserType>, IUserTypeRepository
    {
        public UserTypeRepository(LrsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserType>> GetAllUserTypes()
        {
            return await _context.UserType.ToListAsync();
        }
    }
}
