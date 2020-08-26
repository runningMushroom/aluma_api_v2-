using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("record_of_advise")]
    public class RecordOfAdviseModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid StepId { get; set; }
        public Guid ApplicationId { get; set; }
        public string BdaNumber { get; set; }
        public string AdvisorName { get; set; }
        public string AdvisorEmail { get; set; }
        public string AdvisorMobile { get; set; }
        public string AdviserAddress { get; set; }
        public string Introduction { get; set; }
        public string MaterialInformaiton { get; set; }
        public string DerivedProfile { get; set; }
        public ICollection<RecordOfAdviseItemsModel> SelectedProducts { get; set; }
        public string Replacement_A { get; set; }
        public string Replacement_B { get; set; }
        public string Replacement_C { get; set; }
        public string Replacement_E { get; set; }
        public string ReplacementReason { get; set; }
    }
}