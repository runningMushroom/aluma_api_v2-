using System;
using System.Linq;
using alumaApi.Dto;
using alumaApi.Models.Static;
using alumaApi.RepoWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/authenticate")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public AuthenticationController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("client/{email}/{password}")]
        public IActionResult AuthClient(string email, string password)
        {
            try
            {
                // get account where emails match
                if (!_repo.User.FindByCondition(c => c.Email == email).Any())
                    return StatusCode(401, "Credentials Invalid.");

                var user = _repo.User.FindByCondition(c => c.Email == email).First();

                // verify passwords match
                var match = _repo.StrHasher.ValidateHash(user.Password, password);
                if (!match)
                    return StatusCode(401, "Credentials Invalid");

                var userDto = _mapper.Map<UserDto>(user);

                // generate jwt token
                userDto.Token = _repo.Jwt.CreateJwtToken(user.Id, user.Role);

                return Ok(userDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("admin/{email}/{password}")]
        public IActionResult AuthAdmin(string email, string password)
        {
            try
            {
                // get account where emails match
                if (!_repo.User.FindByCondition(c => c.Email == email && c.Role == Roles.Admin || c.Role == Roles.Broker).Any())
                    return StatusCode(401, "Credentials Invalid.");

                var user = _repo.User.FindByCondition(c => c.Email == email).First();

                // verify passwords match
                if (!_repo.StrHasher.ValidateHash(user.Password, password))
                    return StatusCode(401, "Credentials Invalid");

                var userDto = _mapper.Map<UserDto>(user);

                // generate jwt token
                userDto.Token = _repo.Jwt.CreateJwtToken(user.Id, user.Role);

                return Ok(userDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}