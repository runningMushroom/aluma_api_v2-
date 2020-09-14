using alumaApi.Models.Schedules.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryTrust
{
    [Table("primary_schedule_trust_tax_residency")]
    public class TrustTaxResidencyModel : BaseTaxResidencyModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public PrimaryTrustModel Schedule { get; set; }
        public ICollection<TrustTaxResidencyItemModel> TaxResidencyItems { get; set; }
    }

    public class TrustTaxResidencyModelBuilder : IEntityTypeConfiguration<TrustTaxResidencyModel>
    {
        public void Configure(EntityTypeBuilder<TrustTaxResidencyModel> mb)
        {
            mb.HasMany(c => c.TaxResidencyItems)
                .WithOne(c => c.TrustTaxResidency)
                .HasForeignKey(c => c.TrustTaxResidencyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    [Table("primary_schedule_trust_tax_residency_item")]
    public class TrustTaxResidencyItemModel : BaseTaxResidencyItemModel
    {
        public Guid Id { get; set; }
        public Guid TrustTaxResidencyId { get; set; }
        public TrustTaxResidencyModel TrustTaxResidency { get; set; }
    }
}