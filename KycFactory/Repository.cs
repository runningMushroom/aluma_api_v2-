﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace KycFactory
{
    public interface IKycFactoryRepo
    {
        KycInitiationResponseDto InitiateKycFactory(KycInitiationDto dto);

        RealTimeResultsDto GetKycMetaData(FactoryDetailsDto dto);

        string GetComplianceReport(FactoryDetailsDto dto);
    }

    public class KycFactoryRepo : IKycFactoryRepo
    {
        public readonly KycSettingsDto _settings;

        public KycFactoryRepo()
        {
            var config = new ConfigurationBuilder();
            // Get current directory will return the root dir of Base app as that is the running application
            var path = Path.Join(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _settings = root.GetSection("KycFactory").Get<KycSettingsDto>();
        }

        public KycSettingsDto settings { get => _settings; }

        public KycInitiationResponseDto InitiateKycFactory(KycInitiationDto dto)
        {
            dto.BusinessId = _settings.businessId;

            var client = new RestClient($"{_settings.BaseUrl}Consumer/build-consumer-identity-and-factory");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Basic {_settings.Authorization}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(dto), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new HttpRequestException("KycFactory could not be started");

            return JsonConvert.DeserializeObject<KycInitiationResponseDto>(response.Content);
        }

        public RealTimeResultsDto GetKycMetaData(FactoryDetailsDto dto)
        {
            var client = new RestClient($"{_settings.BaseUrl}Consumer/get-compliance-report-metadata");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Basic {_settings.Authorization}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(dto), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new HttpRequestException("Error while trying to retreive KYC Meta Data");

            MetaDataDto metaDatadto = JsonConvert.DeserializeObject<MetaDataDto>(response.Content);

            return metaDatadto.IdVerify.RealTimeResults;
        }

        public string GetComplianceReport(FactoryDetailsDto dto)
        {
            var client = new RestClient($"{_settings.BaseUrl}Consumer/get-compliance-report");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Basic {_settings.Authorization}");
            request.AddParameter("application/json", JsonConvert.SerializeObject(dto), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new HttpRequestException("Couldn't retreive compliance report");

            var responseData = JsonConvert.DeserializeObject<ComplianceReportDto>(response.Content);

            return responseData.Document;
        }
    }
}