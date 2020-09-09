using Newtonsoft.Json;
using System;

namespace PbVerifyBankValidation
{
    public class SettingsDto
    {
        public string BaseUrl { get; set; }
        public string Authorization { get; set; }
        public string Memberkey { get; set; }
        public string Password { get; set; }
    }

    public class BankValidationResponseDto
    {
        public string Status { get; set; }
        public XdsbvsDto XDSBVS { get; set; }
    }

    public class XdsbvsDto
    {
        public string JobStatus { get; set; }
        public string JobID { get; set; }
    }

    public class VerificationStatusResponse
    {
        public string Status { get; set; }
        public BankVerificationsDto Results { get; set; }
    }

    public class BankVerificationsDto
    {
        [JsonProperty("CLIENTUSERREFERENCE")]
        public string Reference { get; set; }

        [JsonProperty("ACCOUNTTYPE")]
        public string AccountType { get; set; }

        public string VerificationType { get; set; }

        [JsonProperty("BRANCHNUMBER")]
        public string BranchCode { get; set; }

        [JsonProperty("ACCOUNTNUMBER")]
        public string AccountNumber { get; set; }

        [JsonProperty("IDNUMBER")]
        public string IdNumber { get; set; }

        [JsonProperty("INITIALS")]
        public string Initials { get; set; }

        [JsonProperty("INITIALSMATCH")]
        public string InitialsMatch { get; set; }

        [JsonProperty("SURNAME")]
        public string Surname { get; set; }

        [JsonProperty("ACCOUNTFOUND")]
        public string FoundAtBank { get; set; }

        [JsonProperty("ACCOUNT-OPEN")]
        public string AccOpen { get; set; }

        [JsonProperty("ACCOUNTOPENFORATLEASTTHREEMONTHS")]
        public string OlderThan3Months { get; set; }

        [JsonProperty("ACCOUNTTYPERETURN")]
        public string TypeCorrect { get; set; }

        [JsonProperty("IDNUMBERMATCH")]
        public string IdNumberMatch { get; set; }

        [JsonProperty("SURNAMEMATCH")]
        public string SurnameMatch { get; set; }

        [JsonProperty("ACCOUNTACCEPTSDEBITS")]
        public string AcceptDebits { get; set; }

        [JsonProperty("ACCOUNTACCEPTSCREDITS")]
        public string AcceptCredits { get; set; }

        public string BankName { get; set; }
    }
}