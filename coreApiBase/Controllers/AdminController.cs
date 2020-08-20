using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Dto;
using alumaApi.Enum;
using alumaApi.Models.Static;
using alumaApi.RepoWrapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/v1/admin"), Authorize(Roles = "Admin,Broker")]
    public class AdminController : ControllerBase
    {
        private readonly IWrapper _repo;
        private readonly IMapper _mapper;

        public AdminController(IWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("list/clients")]
        public IActionResult ListClients()
        {
            try
            {
                // for now we will list all clients
                // what we really want is that when it's a broker, only clients that he worked on should be listed
                // admins should be the only people who can see all clients

                var clientList = _repo.User.FindByCondition(c => c.Role == Roles.Client).ToList();

                return Ok(clientList);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}