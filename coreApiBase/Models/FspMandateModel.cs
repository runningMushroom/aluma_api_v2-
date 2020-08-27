using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    public class FspMandateModel
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
        public string FLG { get; set; }
        public string FLI { get; set; }
        public string FMG { get; set; }
        public string FMI { get; set; }
        public string FSG { get; set; }
        public string FSI { get; set; }
        public string FConservative { get; set; }
        public string FModeratelyConservative { get; set; }
        public string FModerate { get; set; }
        public string FModeratelyAggressive { get; set; }
        public string FAggressive { get; set; }
        public string AttFull { get; set; }
        public string DateFUll { get; set; }
        public string Adviser { get; set; }
        public string Instruction_personal { get; set; }
        public string Instruction_advisor { get; set; }
        public string Instruction_fsp { get; set; }
        public string Payout_1 { get; set; }
        public string Payout_2 { get; set; }
        public string LLG { get; set; }
        public string LLI { get; set; }
        public string LMG { get; set; }
        public string LMI { get; set; }
        public string LSG { get; set; }
        public string LSI { get; set; }
        public string LConservative { get; set; }
        public string LModeratelyConservative { get; set; }
        public string LModerate { get; set; }
        public string LModeratelyAggressive { get; set; }
        public string LAggressive { get; set; }
        public string AtLimited { get; set; }
        public string DateLimited { get; set; }
    }
}