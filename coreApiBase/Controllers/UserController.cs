using System;
using System.Collections.Generic;
using AutoMapper;
using alumaApi.Dto;
using alumaApi.RepoWrapper;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using alumaApi.Models;

using alumaApi.Enum;
using System.Linq;
using alumaApi.Models.Static;

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
                // check that there are no users with this email or id number
                if (_repo.User.FindByCondition(c => c.Email == dto.Email || c.IdNumber == dto.IdNumber).Any())
                    return StatusCode(403, "Duplicate Client");

                // map dto to user obj
                var user = _mapper.Map<UserModel>(dto);
                user.Role = Roles.Client;

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
                    OtpType = OtpTypesEnum.Registration,
                    UserId = user.Id
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

        [HttpPost("verify/account/{email}/{otp}"), AllowAnonymous]
        public IActionResult VerifyAccount(string email, string otp)
        {
            try
            {
                // get otp object where emails match
                var otpObjList = _repo.Otp.FindByCondition(c => c.ClientEmail == email);

                if (!otpObjList.Any())
                    return StatusCode(404, "OTP Object not found");

                var otpObj = otpObjList.First();

                // check that the otp is valid
                if (otpObj.Otp != otp)
                    return StatusCode(403, "OTP Invalid");

                // get the corrosponding user
                var user = _repo.User.FindByCondition(c => c.Id == otpObj.UserId).First();
                user.MobileVerified = true;

                // update user
                _repo.User.Update(user);

                // remove the otp object
                _repo.Otp.Delete(otpObj);

                // save changes
                _repo.Save();

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}