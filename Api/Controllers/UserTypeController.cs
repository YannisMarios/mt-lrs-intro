using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.DTO;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;
        private readonly ILogService _logger;

        public UserTypeController(IUserTypeService userTypeService, ILogService logger)
        {
            _userTypeService = userTypeService ?? throw new ArgumentNullException(nameof(userTypeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Returns all user types
        /// </summary>
        /// <returns>A<see cref="IEnumerable{UserTypeDto}"/></returns>
        [HttpGet("user-types")]
        public async Task<ActionResult<IEnumerable<UserTypeDto>>> GetAllUserTypes()
        {
            try
            {
                var userTypes = await _userTypeService.GetAllUserTypes();
                return Ok(userTypes);
            } 
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
