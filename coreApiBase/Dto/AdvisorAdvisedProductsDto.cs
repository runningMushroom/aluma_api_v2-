using alumaApi.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class AdvisorAdvisedProductsDto
    {
        public Guid Id { get; set; }
        public Guid AdvisorAdviseId { get; set; }
        public AdvisorAdviseDto AdvisorAdvise { get; set; }
        public string Product { get; set; }
        public double LumpSum { get; set; }
        public double RecurringAmount { get; set; }
    }
}