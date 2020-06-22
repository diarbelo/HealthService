using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace HealthService.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IJWTConfigurator _jwtConfig;

        public AuthController(IRepositoryWrapper repository, IJWTConfigurator jwtConfig)
        {
            _repository = repository;
            _jwtConfig = jwtConfig;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]UserDTO user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("user object is null");
                }

                var userEntity = await _repository.User.GetUserByNameAndPasswordAsync(user.UserName, user.UserPassword);

                if (userEntity != null)
                {
                    var tokenString = _jwtConfig.TokenString(userEntity.UserRol, userEntity.UserName);

                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}