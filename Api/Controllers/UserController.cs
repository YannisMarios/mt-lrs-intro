using System;
using System.Threading.Tasks;
using Api.DTO;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogService _logger;

        public UserController(IUserService userService, ILogService logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Returns paginated results of users
        /// </summary>
        /// <param name="searchParamsDTO">The parameters used to perform user search</param>
        /// <returns>A<see cref="ActionResult{PageDto{UserDto}}}"/> of paginated results</returns>
        [HttpPost("users")]
        public async Task<ActionResult<PageDto<UserDto>>> GetAllUsers([FromBody]SearchUserParamsDto searchParamsDTO)
        {
            try
            {
                var users = await _userService.GetUsers(searchParamsDTO);
                return Ok(users);
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Returns a user by id
        /// </summary>
        /// <param name="id">The id of the user to get</param>
        /// <returns><see cref="ActionResult{UserDto}"/></returns>
        [HttpGet("users/{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The user data</param>
        /// <returns><see cref="ActionResult{UserDto}"/></returns>
        [HttpPost("users/add")]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto user)
        {
            try
            {
                var createdUser = await _userService.CreateUser(user);
                return Ok(createdUser);
            }
            catch(ArgumentNullException ex) {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="userId">The id of the user to get</param>
        /// <param name="user">The user data</param>
        /// <returns><see cref="ActionResult{UserDto}"/></returns>
        [HttpPut("users/edit/{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody]UserDto user)
        {
            try
            {
                var updatedUser = await _userService.UpdateUser(id, user);
                return Ok(updatedUser);
            }
            catch (ArgumentException ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="id">The id of the user to delete</param>
        /// <returns>A<see cref="IActionResult"/></returns>
        [HttpDelete("users/delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
