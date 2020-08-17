using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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

        public async Task SendOTPAsync(string mobile, string otp)
        {
            // get last 9 digits from the string: mystring.Substring(mystring.Length - 4);
            var mobileNo = mobile.Substring(mobile.Length - 9);

            // create http client
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(_settings.BaseUrl);

            client.DefaultRequestHeaders
              .Accept
              .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _settings.ApiToken);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "messages");

            request.Content = new StringContent(
                JsonConvert.SerializeObject(new
                {
                    mobile = mobileNo,
                    message = otp,
                    userSuppliedId = "Aluma"
                }), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception();
        }
    }
}