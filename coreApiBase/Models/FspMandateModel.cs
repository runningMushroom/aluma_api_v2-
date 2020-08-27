using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("fsp_mandate")]
    public class FspMandateModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid stepId { get; set; }
        public Guid ApplicationId { get; set; }
        public string ClientDetails { get; set; }
        public string Products { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string AccNo { get; set; }
        public string StartDate { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string Address_3 { get; set; }
        public string Email { get; set; }
        public string FspSignatory { get; set; }
        public string AtFsp { get; set; }
        public string DateFsp { get; set; }
        public string AtClient { get; set; }
        public string DateClient { get; set; }
        public string Objective { get; set; }
        public string InstructionPersonal { get; set; }
        public string InstructionAdvisor { get; set; }
        public string InstructionFsp { get; set; }
        public string Advisor { get; set; }
        public string Payout_1 { get; set; }
        public string Payout_2 { get; set; }
    }
}