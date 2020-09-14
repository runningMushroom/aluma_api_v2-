using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryTrust
{
    [Table("primary_schedule_trust_entity_classification")]
    public class TrustEntityModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public PrimaryTrustModel Schedule { get; set; }
        public string FatchaPartner { get; set; }
        public string Managed { get; set; }
        public string OtherInvestment { get; set; }
        public string Depository { get; set; }
        public string GlobalIntermediaryId { get; set; }
        public string DocumentedTrust { get; set; }
        public string ManaginInstitutionName { get; set; }
        public string ManaginInstitutionGiin { get; set; }
        public string ManaginInstitutionCountry { get; set; }
        public string ComplaintFi { get; set; }
        public string ExemptOwner { get; set; }
        public string OwnerDocumented { get; set; }
        public string NonReporting { get; set; }
        public string AwaitingGiin { get; set; }
        public string Limited { get; set; }
        public string NonParticipating { get; set; }
        public string Other { get; set; }
        public string RegularTradeRelationTrue { get; set; }
        public string EntityName { get; set; }
        public string StockExchangeName { get; set; }
        public string GovernmentEntityTrue { get; set; }
        public string NfeInternationalTrue { get; set; }
        public string NfeLiquidatingTrue { get; set; }
        public string NfeTreasuryTrue { get; set; }
        public string NfeDirectTrue { get; set; }
        public string NfeDirectName { get; set; }
        public string SponsorName { get; set; }
        public string SponsorGiin { get; set; }
        public string NonProfit { get; set; }
        public string NonProfitDetails { get; set; }
        public string HightPassive { get; set; }
    }
}