using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("kyc_meta_data")]
    public class KycMetaDataModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public ApplicationsModel Application { get; set; }
        public string IdNumber { get; set; }
        public string FirstNames { get; set; }
        public string SurName { get; set; }
        public string Dob { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Citizenship { get; set; }
        public string DeceasedStatus { get; set; }
        public string CellNumber { get; set; }
        public string Email { get; set; }
    }
}