using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class BankVerificationsDto
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid StepId { get; set; }
        public string Name { get; set; }
        public string SearchData { get; set; }
        public string Reference { get; set; }
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