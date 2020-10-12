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
    public class UserTitleController : ControllerBase
    {
        private readonly IUserTitleService _userTitleService;
        private readonly ILogService _logger;

        public UserTitleController(IUserTitleService userTitleService, ILogService logger)
        {
            _userTitleService = userTitleService ?? throw new ArgumentNullException(nameof(userTitleService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Returns all user titles
        /// </summary>
        /// <returns>A<see cref="IEnumerable{UserTitleDto}"/></returns>
        [HttpGet("user-titles")]
        public async Task<ActionResult<IEnumerable<UserTitleDto>>> GetAllUserTitles()
        {
            try
            {
                var userTitles = await _userTitleService.GetAllUserTitles();
                return Ok(userTitles);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
