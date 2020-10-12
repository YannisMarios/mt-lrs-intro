using Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories.Interfaces
{
    public interface IUserTypeRepository: IRepository<UserType>
    {
        /// <summary>
        /// Gets all user types
        /// </summary>
        /// <returns>A<see cref="IEnumerable{UserType}"/></returns>
        Task<IEnumerable<UserType>> GetAllUserTypes();
    }
}
