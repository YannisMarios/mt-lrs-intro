using Api.DTO;
using System.Threading.Tasks;

namespace Api.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Returns paginated results of users
        /// </summary>
        /// <param name="searchParamsDTO">The parameters used to perform user search</param>
        /// <returns>A<see cref="PagDto{UserDto}"/>  paginated results</returns>
        Task<PageDto<UserDto>> GetUsers(SearchUserParamsDto searchParamsDTO);

        /// <summary>
        /// Returns a user by id
        /// </summary>
        /// <param name="userId">The id of the user to get</param>
        /// <returns>A<see cref="UserDto"/></returns>
        Task<UserDto> GetUser(int userId);

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The user data</param>
        /// <returns>A<see cref="UserDto"/></returns>
        Task<UserDto> CreateUser(UserDto user);

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="id">The id of the user to update</param>
        /// <param name="user">The user data</param>
        /// <returns>A<see cref="UserDto"/></returns>
        Task<UserDto> UpdateUser(int id, UserDto user);

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id">The id of the user to delete</param>
        /// <returns></returns>
        Task DeleteUser(int id);
    }
}
