using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class UserTitleRepository : Repository<UserTitle>, IUserTitleRepository
    {
        public UserTitleRepository(LrsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserTitle>> GetAllUserTitles()
        {
            return await _context.UserTitle.ToListAsync();
        }
    }
}
