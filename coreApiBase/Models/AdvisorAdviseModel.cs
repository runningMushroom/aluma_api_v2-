using alumaApi.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("advisor_advise")]
    public class AdvisorAdviseModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid StepId { get; set; }
        public Guid AdvisorId { get; set; }
        public string Introduction { get; set; }
        public string Notes { get; set; }
        public string MaterialInformation { get; set; }
        public ICollection<AdvisorAdvisedProductsModel> AdvisedProducts { get; set; }
    }

    public class AdvisorAdviseModelBuilder : IEntityTypeConfiguration<AdvisorAdviseModel>
    {
        public void Configure(EntityTypeBuilder<AdvisorAdviseModel> mb)
        {
            mb.HasMany(c => c.AdvisedProducts)
                .WithOne(c => c.AdvisorAdvise)
                .HasForeignKey(c => c.AdvisorAdviseId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}