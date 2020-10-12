using Api.Models;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(LrsContext context) : base(context)
        {
            
        }

        public async Task<Page<User>> GetUsers(SearchUsersParams searchParams)
        {
            var users = _context.User
				.Include(x => x.UserType)
				.Include(x => x.UserTitle)
				.Where(x => x.IsActive == true)
				.AsQueryable();

            var totalCount = await users.CountAsync().ConfigureAwait(false);
            var searchCount = 0;
            if (!string.IsNullOrWhiteSpace(searchParams.SearchString))
            {
                users = users.Where(l => l.Name.ToLower().Contains(searchParams.SearchString) ||
                l.Surname.ToLower().Contains(searchParams.SearchString));
                searchCount = users.Count();
            }

			var results = await users
				.OrderBy(l => l.Id)
				.Skip(searchParams.PageIndex * searchParams.PageSize)
				.Take(searchParams.PageSize)
				.ToListAsync()
				.ConfigureAwait(false);

			var pageCount = searchCount == 0 ?
				Utils.PageCount(totalCount, searchParams.PageSize) :
				Utils.PageCount(searchCount, searchParams.PageSize);
			var currentPage = searchParams.PageIndex > pageCount  ? pageCount : searchParams.PageIndex;

			var Page = new Page<User>
			{
				Items = results,
				PageCount = pageCount,
				TotalCount = totalCount,
				CurrentPage = currentPage
			};


			return Page;
		}

		public async Task<User> GetUser(int id)
		{
			return await _context.User
				.Include(x => x.UserType)
				.Include(x => x.UserTitle)
				.SingleOrDefaultAsync(x => x.Id.Equals(id))
				.ConfigureAwait(false);
		}

		public async Task<User> CreateUser(User user)
		{
			_context.Add(user);
			await _context.SaveChangesAsync().ConfigureAwait(false);
			return user;
		}


		public async Task<User> UpdateUser(int id, User userData)
        {
			var user = await _context.User.SingleOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);

			if(user != null)
            {
				user.Name = userData.Name;
				user.Surname = userData.Surname;
				user.IsActive = userData.IsActive;
				user.UserTypeId = userData.UserTypeId;
				user.UserTitleId = userData.UserTitleId;
				user.EmailAddress = userData.EmailAddress;

				 _context.User.Update(user);
				await _context.SaveChangesAsync();
            }

			return user;
		}

		public async Task DeleteUser(int id)
        {
			var user = await _context.User.SingleOrDefaultAsync(x => x.Id.Equals(id)).ConfigureAwait(false);

			if(user != null)
            {
				user.IsActive = false;

				_context.User.Update(user);
				await _context.SaveChangesAsync();
			}
		}
    }
}
