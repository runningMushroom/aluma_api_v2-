using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BulkSms
{
    public class BulkSmsRepo : IBulkSmsRepo
    {
        public readonly SmsSettings _settings;

        public BulkSmsRepo()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Join(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _settings = root.GetSection("BulkSmsSettings").Get<SmsSettings>();
        }

        public SmsSettings settings { get => _settings; }

        private static readonly Random random = new Random();

        public string CreateOtp()
        {
            var chars = "0123456789";

            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public bool SendOtop(string mobile, string message)
        {
            // get last 9 digits from the string: mystring.Substring(mystring.Length - 4);
            var mobileNo = mobile.Substring(mobile.Length - 9);

            var client = new RestClient($"{_settings.BaseUrl}messages");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Authorization", $"Basic ${_settings.ApiToken}");
            // TODO: fix this to use the api code from the appsettings file
            request.AddHeader("Authorization", "Basic OUIyRDQ2RjlFMEZENEQ0OUE4MEU2ODM4NTA2NkU0QjItMDEtNzpQbXlxdHlXSW5MZXlRUDBiUkJoeW9IZklDTzhObg==");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n    \"to\": \"+27" + mobileNo + "\",\r\n \"body\": \"" + message + "\"\r\n}", ParameterType.RequestBody);
            //request.AddParameter("application/json", "{\r\n    \"to\": \"+27812584450\",\r\n    \"body\": \"an all new hell...\"\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response.IsSuccessful ? true : false;
        }
    }
}