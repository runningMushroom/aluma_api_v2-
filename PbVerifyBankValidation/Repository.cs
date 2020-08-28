using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace PbVerifyBankValidation
{
    public interface IPvBerifyBankValidationRepo
    {
        BankValidationResponseDto StartBankValidation(BankVerificationsDto dto);

        VerificationStatusResponse GetBankValidationStatus(string jobId);
    }

    public class PvBerifyBankValidationRepo : IPvBerifyBankValidationRepo
    {
        public readonly SettingsDto _settings;

        public PvBerifyBankValidationRepo()
        {
            var config = new ConfigurationBuilder();
            // Get current directory will return the root dir of Base app as that is the running application
            var path = Path.Join(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _settings = root.GetSection("PbVerifyBankValidation").Get<SettingsDto>();
        }

        public SettingsDto settings { get => _settings; }

        public BankValidationResponseDto StartBankValidation(BankVerificationsDto dto)
        {
            var client = new RestClient($"{_settings.BaseUrl}pbv-bank-account-verification");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Basic ${_settings.Authorization}");
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("memberkey", _settings.Memberkey);
            request.AddParameter("password", _settings.Password);
            request.AddParameter("bvs_details[verificationType]", dto.VerificationType);
            request.AddParameter("bvs_details[acc_number]", dto.AccountNumber);
            request.AddParameter("bvs_details[acc_type]", dto.AccountType);
            request.AddParameter("bvs_details[id_number]", dto.IdNumber);
            request.AddParameter("bvs_details[initials]", dto.Initials);
            request.AddParameter("bvs_details[surname]", dto.Surname);
            request.AddParameter("bvs_details[yourReference]", dto.Reference);
            request.AddParameter("bvs_details[bank_name]", dto.BankName);
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new HttpRequestException("Error while trying to start Bank Account Validation");

            BankValidationResponseDto responseData = JsonConvert.DeserializeObject<BankValidationResponseDto>(response.Content);

            return responseData;
        }

        public VerificationStatusResponse GetBankValidationStatus(string jobId)
        {
            var client = new RestClient($"{_settings.BaseUrl}pbv-bank-account-verification");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Basic ${_settings.Authorization}");
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("memberkey", _settings.Memberkey);
            request.AddParameter("password", _settings.Password);
            request.AddParameter("jobId", jobId);
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new HttpRequestException("Error while trying to start Bank Account Validation Status");

            return JsonConvert.DeserializeObject<VerificationStatusResponse>(response.Content);
        }
    }
}