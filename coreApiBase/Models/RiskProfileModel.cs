using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("risk_profile")]
    public class RiskProfileModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid StepId { get; set; }
        public Guid ApplicationId { get; set; }
        public string Client { get; set; }
        public string IdentityNumber { get; set; }
        public string Advisor { get; set; }
        public string CreatedOn { get; set; }
        public string Goal { get; set; }
        public string InvestmentTerm { get; set; }
        public string RequiredRisk { get; set; }
        public string RiskTolerance { get; set; }
        public string RiskCapacity { get; set; }
        public string DerivedProfile { get; set; }
        public bool AgreeWithOutcome { get; set; }
        public string Reason { get; set; }
        public string AdvisorNotes { get; set; }
        public string Date { get; set; }
    }
}