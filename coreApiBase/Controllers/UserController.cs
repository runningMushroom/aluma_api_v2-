using System;
using System.Collections.Generic;
using AutoMapper;
using alumaApi.Dto;
using alumaApi.RepoWrapper;
using alumaApi.Static;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using alumaApi.Models;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/user"), Authorize]
    public class UserController : Controller
    {
        private readonly IWrapper _wrapper;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly SystemSettingsDto _settings;

        public UserController(IWrapper wrapper, ILogger<UserController> logger, IMapper mapper,
            SystemSettingsDto settings)
        {
            _wrapper = wrapper;
            _logger = logger;
            _mapper = mapper;
            _settings = settings;
        }

        [HttpPost("create"), AllowAnonymous]
        public IActionResult CreateUser([FromBody] RegistrationDto newUser)
        {
            try
            {
                newUser.Password = _wrapper.StrHasher.CreateHash(newUser.Password);
                newUser.MobileNumber = $"27{newUser.MobileNumber}";

                // map newUser to userDto
                var user = _mapper.Map<UserModel>(newUser);

                // set user role to user
                user.Role = RoleEnum.Client;

                // save to database
                _wrapper.User.Create(user);
                _wrapper.Save();

                // create email verification token
                var token = _wrapper.TokenProvider.CreateToken(
                    new TokenProvider.ClaimsDto()
                    {
                        Email = user.Email,
                        IdNumber = user.IdNumber,
                        Mobile = user.MobileNumber,
                        Password = string.Empty,
                        Role = user.Role.ToString(),
                        SystemId = user.Id.ToString(),
                        TokenType = "Email Verification"
                    }, 48);

                // start hangfire que to send registration email
                BackgroundJob.Enqueue(() => _wrapper.SendMail.CreateHtmlMessage(
                    new MailSender.MailSenderMessageDto()
                    {
                        Subject = "Verify your email address",
                        CcUsers = new Dictionary<string, string>(),
                        ToUsers = new Dictionary<string, string>() { { user.FirstName, user.Email } }
                    },
                    "VerifyEmail.html",
                    $"Token: {token}",
                    $"Role:  {user.Role}",
                    $"URL: {_settings.FrontendUrl}{user.Id}/{token}"
                    ));

                // return Created Ok
                return StatusCode(201);
            }
            catch (DbUpdateException e)
            {
                string error = $"SqlException at UserController.CreateUser:  {e}";
                _logger.LogError(error);
                return StatusCode(403, "Database Update Exception at UserController.CreateUser");
            }
            catch (Exception e)
            {
                string error = $"Exception at UserController.CreateUser:  {e}";
                _logger.LogError(error);
                return StatusCode(500, error);
            }
        }

        [HttpPost("authenticate")]
        public IActionResult AuthenticateUser()
        {
            return Ok();
        }
    }
}