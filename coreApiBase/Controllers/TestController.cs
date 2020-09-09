using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace alumaApi.Controllers
{
    [ApiController, Route("api/test")]
    public class TestController : ControllerBase
    {
        public class BankUserRegistrationItems
        {
            public string email { get; set; }
            public string first_name { get; set; }
            public string password { get; set; }
            public string surname { get; set; }
        }

        [HttpPost]
        public IActionResult BankUserRegistration([FromBody] BankUserRegistrationItems dto)
        {
            try
            {
                var client = new RestClient("https://bankapilayer.moola.za.com/api/BankApiLayer/BankUserRegistration");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(dto), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}