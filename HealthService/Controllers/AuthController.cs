using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using JWTService.Tools;
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
        private IMapper _mapper;
        public AuthController(IRepositoryWrapper repository, IJWTConfigurator jwtConfig, IMapper mapper)
        {
            _repository = repository;
            _jwtConfig = jwtConfig;
            _mapper = mapper;
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
              
                var userEntity = await _repository.User.GetUserByNameAndPasswordAsync(user.UserMail, user.UserPassword);

                var userResult = _mapper.Map<UserResponseDTO>(userEntity);

                if (userEntity != null)
                {
                    //var tokenString = _jwtConfig.TokenString(userEntity.UserRol, userEntity.UserName);
                    userResult.Token = _jwtConfig.TokenString(userEntity.UserRol, userEntity.UserName);

                    //return Ok(new { Token = tokenString });
                    return Ok(userResult);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}