using Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories.Interfaces
{
    public interface IUserTitleRepository : IRepository<UserTitle>
    {
        /// <summary>
        /// Gets all user titles
        /// </summary>
        /// <returns>A<see cref="IEnumerable{UserTitle}"/></returns>
        Task<IEnumerable<UserTitle>> GetAllUserTitles();
    }
}
