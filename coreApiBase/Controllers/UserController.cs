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
using Entities.Dto;

using alumaApi.Models;

using alumaApi.Enum;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/user"), Authorize]
    public class UserController : Controller
    {
        private readonly IWrapper _repo;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly SystemSettingsDto _settings;

        public UserController(IWrapper wrapper, ILogger<UserController> logger, IMapper mapper, SystemSettingsDto settings)
        {
            _repo = wrapper;
            _logger = logger;
            _mapper = mapper;
            _settings = settings;
        }

        [HttpPost("create"), AllowAnonymous]
        public IActionResult Create([FromBody] UserDto dto)
        {
            try
            {
                // map dto to user obj
                var user = _mapper.Map<UserModel>(dto);
                user.Role = RoleEnum.Client;

                // hash user password
                user.Password = _repo.StrHasher.CreateHash(dto.Password);

                // create client
                _repo.User.Create(user);

                // create otp
                var otp = _repo.BulkSms.CreateOtp();
                _repo.Otp.Create(new OtpModel()
                {
                    ClientEmail = user.Email,
                    Otp = otp,
                    OtpType = OtpTypesEnum.Registration
                });

                // send otp
                var otpSent = _repo.BulkSms.SendOtop(user.MobileNumber, $"Your Aluma Registraiton OTP: {otp}");

                if (!otpSent)
                    return StatusCode(500, "Couldn't send OTP, Please retry or contact support");

                // save changes
                _repo.Save();

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}