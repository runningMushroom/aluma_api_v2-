using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.Shared
{
    public class BaseTaxResidencyModel : BaseModel
    {
        public string TaxNumber { get; set; }
        public string PersonUsTaxObligations { get; set; }
        public string UsRegistered { get; set; }
        public string UsJurisdiction { get; set; }
        public string AnyUsPersons { get; set; }
        public string TrustUsTaxObligations { get; set; }
        public string InternationalObligations { get; set; }
        public string UsOther { get; set; }
    }
}