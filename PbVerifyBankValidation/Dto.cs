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
        public string Name { get; set; }
        public string SearchData { get; set; }
        public string Reference { get; set; }
        public string BankName { get; set; }
        public string AccountType { get; set; }
        public string VerificationType { get; set; }
        public string BranchCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountId { get; set; }
        public string IdNumber { get; set; }
        public string Initials { get; set; }
        public string Surname { get; set; }
        public string FoundAtBank { get; set; }
        public string AccOpen { get; set; }
        public string OlderThan3Months { get; set; }
        public string TypeCorrect { get; set; }
        public string IdNumberMatch { get; set; }
        public string NamesMatch { get; set; }
        public string AcceptDebits { get; set; }
        public string AcceptCredits { get; set; }
    }
}