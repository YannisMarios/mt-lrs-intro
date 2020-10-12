
using Api.Models;
using System.Threading.Tasks;

namespace Api.Repositories.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        /// <summary>
        /// Returns paginated results of users
        /// </summary>
        /// <param name="searchParams">The parameters used to perform user search</param>
        /// <returns>A<see cref="Page{User}"/>of paginated results</returns>
        Task<Page<User>> GetUsers(SearchUsersParams searchParams);

        /// <summary>
        /// Returns a user by id
        /// </summary>
        /// <param name="id">The id of the user to get</param>
        /// <returns>A<see cref="User"/></returns>
        Task<User> GetUser(int id);

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The user data</param>
        /// <returns>A<see cref="User"/></returns>
        Task<User> CreateUser(User user);

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="id">The id of the user to update</param>
        /// <param name="user">The user data</param>
        /// <returns>A<see cref="User"/></returns>
        Task<User> UpdateUser(int id, User user);

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id">The id of the user to delete</param>
        /// <returns></returns>
        Task DeleteUser(int id);
    }
}
