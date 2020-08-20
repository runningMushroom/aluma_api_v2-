using alumaApi.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("advisor_advised_products")]
    public class AdvisorAdvisedProductsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid AdvisorAdviseId { get; set; }
        public AdvisorAdviseModel AdvisorAdvise { get; set; }
        public ProductsEnum Product { get; set; }
        public double LumpSum { get; set; }
        public double RecurringAmount { get; set; }
    }
}